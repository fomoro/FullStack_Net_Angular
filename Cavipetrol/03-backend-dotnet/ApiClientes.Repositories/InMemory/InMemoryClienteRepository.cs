using ApiClientes.Domain.Entities;
using ApiClientes.Services.Ports.Outbound;

namespace ApiClientes.Repositories.InMemory;

/// <summary>
/// Adaptador de Salida Mock en Memoria para pruebas locales instantáneas y resiliencia en demostración.
/// </summary>
public class InMemoryClienteRepository : IClienteRepository
{
    private static readonly List<Cliente> _clientesSeed = new()
    {
        new Cliente
        {
            IdCliente = 1,
            Identificacion = "12345678",
            Nombre = "Carlos",
            Apellido = "Mendoza",
            Email = "carlos.mendoza@cavipetrol.com",
            FechaCreacion = DateTime.Parse("2026-01-15T10:00:00Z"),
            FechaActualizacion = null,
            Genero = 'M',
            FechaNacimiento = DateTime.Parse("1985-04-12"),
            Estado = "Activo",
            Categoria = "VIP"
        },
        new Cliente
        {
            IdCliente = 2,
            Identificacion = "10987654",
            Nombre = "María Fernanda",
            Apellido = "Gómez",
            Email = "maria.gomez@cavipetrol.com",
            FechaCreacion = DateTime.Parse("2026-02-01T14:30:00Z"),
            FechaActualizacion = null,
            Genero = 'F',
            FechaNacimiento = DateTime.Parse("1992-08-25"),
            Estado = "Activo",
            Categoria = "Frecuente"
        },
        new Cliente
        {
            IdCliente = 3,
            Identificacion = "11223344",
            Nombre = "Juan Pablo",
            Apellido = "Martínez",
            Email = "juan.martinez@cavipetrol.com",
            FechaCreacion = DateTime.Parse("2026-03-10T09:15:00Z"),
            FechaActualizacion = null,
            Genero = 'M',
            FechaNacimiento = DateTime.Parse("2012-05-10"),
            Estado = "Activo",
            Categoria = "Estándar"
        }
    };

    public Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken cancellationToken = default)
    {
        var cliente = _clientesSeed.FirstOrDefault(c => string.Equals(c.Identificacion, identificacion, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(cliente);
    }
}
