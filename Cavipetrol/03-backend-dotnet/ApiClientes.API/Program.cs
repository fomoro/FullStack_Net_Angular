using System.Text;
using ApiClientes.API.Middlewares;
using ApiClientes.Repositories.Context;
using ApiClientes.Repositories.InMemory;
using ApiClientes.Repositories.SqlServer;
using ApiClientes.Services.Ports.Inbound;
using ApiClientes.Services.Ports.Outbound;
using ApiClientes.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Controladores y Swagger UI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Clientes Cavipetrol",
        Version = "v1",
        Description = "API REST Hexagonal para consulta de clientes con estrategia Dual Provider (SqlServer/InMemory)."
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Encabezado de Autorización JWT usando el esquema Bearer. Ejemplo: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// 2. Configuración de Seguridad JWT (Zero Trust Resource Server - ADR-004)
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["Secret"] ?? "CavipetrolSecretKeySuperSegura2026_ExecutiveArchitectureTokenKey";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"] ?? "Cavipetrol.IdentityServer",
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"] ?? "Cavipetrol.ApiClientes",
        ClockSkew = TimeSpan.Zero
    };
});

// 3. Configuración de CORS (Permite llamadas desde Angular SPA e Ionic)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// 4. Inyección de Dependencias (Estrategia Dual Provider - ADR-003)
var dataProvider = builder.Configuration["DataProvider"] ?? "InMemory";

if (string.Equals(dataProvider, "SqlServer", StringComparison.OrdinalIgnoreCase))
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApiClientesDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddScoped<IClienteRepository, SqlServerClienteRepository>();
}
else
{
    // Fallback Mock InMemory para evaluación inmediata y resiliencia local
    builder.Services.AddSingleton<IClienteRepository, InMemoryClienteRepository>();
}

builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

// 5. Pipeline de Procesamiento HTTP
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Clientes v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
