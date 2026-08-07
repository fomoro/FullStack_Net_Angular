using ApiClientes.Domain.Entities;
using ApiClientes.DTOs;
using ApiClientes.Services.Ports.Inbound;
using ApiClientes.Services.Ports.Outbound;

namespace ApiClientes.Services.Services;

/// <summary>
/// Caso de uso de Aplicación para consulta de clientes.
/// Implementa IClienteService respetando guard clauses e inversión de dependencias.
/// </summary>
public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ApiResponse<ClienteDto>> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken cancellationToken = default)
    {
        // Guard Clause: Validación de precondición
        if (string.IsNullOrWhiteSpace(identificacion))
        {
            return ApiResponse<ClienteDto>.Fallido(
                "El número de identificación es obligatorio",
                new List<string> { "La identificación no puede estar vacía ni contener solo espacios" }
            );
        }

        var cliente = await _repository.ObtenerPorIdentificacionAsync(identificacion.Trim(), cancellationToken);

        if (cliente == null)
        {
            return ApiResponse<ClienteDto>.Fallido(
                $"No se encontró ningún cliente registrado con la identificación '{identificacion}'"
            );
        }

        var dto = MapearADto(cliente);
        return ApiResponse<ClienteDto>.Exitoso(dto, "Cliente consultado exitosamente");
    }

    private static ClienteDto MapearADto(Cliente cliente)
    {
        return new ClienteDto
        {
            IdCliente = cliente.IdCliente,
            Identificacion = cliente.Identificacion,
            Nombre = cliente.Nombre,
            Apellido = cliente.Apellido,
            Email = cliente.Email,
            FechaCreacion = cliente.FechaCreacion,
            FechaActualizacion = cliente.FechaActualizacion,
            Genero = cliente.Genero,
            FechaNacimiento = cliente.FechaNacimiento,
            Estado = cliente.Estado,
            Categoria = cliente.Categoria
        };
    }
}
