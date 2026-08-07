namespace ApiClientes.DTOs;

/// <summary>
/// DTO de transferencia de información del cliente hacia capas externas.
/// </summary>
public record ClienteDto
{
    public int IdCliente { get; init; }
    public string Identificacion { get; init; } = string.Empty;
    public string Nombre { get; init; } = string.Empty;
    public string Apellido { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime FechaCreacion { get; init; }
    public DateTime? FechaActualizacion { get; init; }
    public char? Genero { get; init; }
    public DateTime? FechaNacimiento { get; init; }
    public string Estado { get; init; } = string.Empty;
    public string Categoria { get; init; } = string.Empty;
}
