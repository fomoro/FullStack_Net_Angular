using ApiClientes.Domain.Entities;
using ApiClientes.Services.Ports.Outbound;

namespace ApiClientes.Repositories.InMemory;

/// <summary>
/// Adaptador de Salida Mock en Memoria para pruebas locales instantáneas y resiliencia en demostración.
/// </summary>
public class InMemoryClienteRepository : IClienteRepository
{
    private const int CantidadClientesDemo = 30;

    private static readonly IReadOnlyList<Cliente> ClientesPrincipales =
    [
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
    ];

    private static readonly IReadOnlyList<Cliente> _clientesSeed = ClientesPrincipales
        .Concat(CrearClientesGenerados())
        .ToArray();

    public Task<IReadOnlyCollection<Cliente>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult<IReadOnlyCollection<Cliente>>(_clientesSeed);
    }

    public Task<Cliente?> ObtenerPorIdentificacionAsync(string identificacion, CancellationToken cancellationToken = default)
    {
        var cliente = _clientesSeed.FirstOrDefault(c => string.Equals(c.Identificacion, identificacion, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(cliente);
    }

    private static IReadOnlyCollection<Cliente> CrearClientesGenerados()
    {
        return Enumerable.Range(4, CantidadClientesDemo - ClientesPrincipales.Count)
            .Select(id => new Cliente
            {
                IdCliente = id,
                Identificacion = $"100000{id:D2}",
                Nombre = $"Cliente {id:D2}",
                Apellido = "Demostración",
                Email = $"cliente{id:D2}@cavipetrol.com",
                FechaCreacion = new DateTime(2026, 1, 1, 8, 0, 0, DateTimeKind.Utc).AddDays(id),
                FechaActualizacion = id % 4 == 0 ? new DateTime(2026, 7, 1, 8, 0, 0, DateTimeKind.Utc).AddDays(id) : null,
                Genero = id % 2 == 0 ? 'M' : 'F',
                FechaNacimiento = new DateTime(1980 + id % 25, id % 12 + 1, id % 27 + 1),
                Estado = ObtenerEstadoDemo(id),
                Categoria = ObtenerCategoriaDemo(id)
            })
            .ToArray();
    }

    private static string ObtenerEstadoDemo(int id)
    {
        return id switch
        {
            10 or 20 => "Inactivo",
            15 or 30 => "Validación",
            _ => "Activo"
        };
    }

    private static string ObtenerCategoriaDemo(int id)
    {
        if (id % 7 == 0)
        {
            return "VIP";
        }

        return id % 3 == 0 ? "Frecuente" : "Estándar";
    }
}
