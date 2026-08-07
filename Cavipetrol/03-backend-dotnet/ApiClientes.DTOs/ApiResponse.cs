namespace ApiClientes.DTOs;

/// <summary>
/// Respuesta unificada estándar para todos los endpoints de la API.
/// </summary>
public record ApiResponse<T>
{
    public bool Exito { get; init; }
    public string Mensaje { get; init; } = string.Empty;
    public T? Datos { get; init; }
    public List<string> Errores { get; init; } = new();
    public DateTime FechaUtc { get; init; } = DateTime.UtcNow;

    public static ApiResponse<T> Exitoso(T datos, string mensaje = "Operación realizada con éxito")
    {
        return new ApiResponse<T>
        {
            Exito = true,
            Mensaje = mensaje,
            Datos = datos
        };
    }

    public static ApiResponse<T> Fallido(string mensaje, List<string>? errores = null)
    {
        return new ApiResponse<T>
        {
            Exito = false,
            Mensaje = mensaje,
            Datos = default,
            Errores = errores ?? new List<string>()
        };
    }
}
