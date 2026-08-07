namespace ApiClientes.Domain.Entities;

/// <summary>
/// Entidad de dominio pura que representa un Cliente.
/// Encapsula el modelo de datos y las reglas invariantes de negocio.
/// </summary>
public class Cliente
{
    public int IdCliente { get; set; }
    public string Identificacion { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaActualizacion { get; set; }
    public char? Genero { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string Estado { get; set; } = "Activo";
    public string Categoria { get; set; } = "Estándar";

    public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
}
