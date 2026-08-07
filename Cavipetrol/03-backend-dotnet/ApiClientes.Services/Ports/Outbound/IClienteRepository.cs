using ApiClientes.Domain.Entities;

namespace ApiClientes.Services.Ports.Outbound;

/// <summary>
/// Puerto de salida (Driven Port) para la abstracción de persistencia de Clientes.
/// </summary>
public interface IClienteRepository
{
    Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken cancellationToken = default);
}
