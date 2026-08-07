using ApiClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Repositories.Context;

/// <summary>
/// DbContext de EF Core mapeado a la tabla dbo.Clientes.
/// </summary>
public class ApiClientesDbContext : DbContext
{
    public ApiClientesDbContext(DbContextOptions<ApiClientesDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("Clientes", "dbo");
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.Identificacion)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Genero)
                .HasConversion<string>();

            entity.Property(e => e.Estado)
                .HasMaxLength(20);

            entity.Property(e => e.Categoria)
                .HasMaxLength(30);
        });
    }
}
