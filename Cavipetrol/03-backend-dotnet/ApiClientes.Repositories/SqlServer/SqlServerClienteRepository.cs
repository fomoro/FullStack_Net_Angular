using ApiClientes.Domain.Entities;
using ApiClientes.Repositories.Context;
using ApiClientes.Services.Ports.Outbound;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Repositories.SqlServer;

/// <summary>
/// Adaptador de Salida para SQL Server utilizando EF Core y Stored Procedure sp_ObtenerClientePorIdentificacion.
/// </summary>
public class SqlServerClienteRepository : IClienteRepository
{
    private readonly ApiClientesDbContext _context;

    public SqlServerClienteRepository(ApiClientesDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IReadOnlyCollection<Cliente>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Clientes
            .AsNoTracking()
            .OrderBy(cliente => cliente.IdCliente)
            .ToListAsync(cancellationToken);
    }

    public async Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken cancellationToken = default)
    {
        var param = new SqlParameter("@Identificacion", identificacion);

        var resultados = await _context.Clientes
            .FromSqlRaw("EXEC dbo.sp_ObtenerClientePorIdentificacion @Identificacion", param)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return resultados.FirstOrDefault();
    }
}
