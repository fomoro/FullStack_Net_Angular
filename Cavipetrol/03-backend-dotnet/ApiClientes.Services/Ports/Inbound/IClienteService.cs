using ApiClientes.DTOs;

namespace ApiClientes.Services.Ports.Inbound;

/// <summary>
/// Puerto de entrada (Driving Port) para los casos de uso de Clientes.
/// </summary>
public interface IClienteService
{
    Task<ApiResponse<ClienteDto>> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken cancellationToken = default);
}
