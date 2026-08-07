using ApiClientes.DTOs;
using ApiClientes.Services.Ports.Inbound;
using Microsoft.AspNetCore.Mvc;

namespace ApiClientes.API.Controllers;

/// <summary>
/// Adaptador de Entrada REST (Thin Controller) para la gestión y consulta de clientes.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
    }

    /// <summary>
    /// Consulta la información de un cliente por su número de identificación.
    /// </summary>
    /// <param name="identificacion">Número de cédula o documento del cliente</param>
    /// <param name="cancellationToken">Token de cancelación</param>
    /// <returns>Objeto unificado ApiResponse con los datos del cliente</returns>
    [HttpGet("{identificacion}")]
    [ProducesResponseType(typeof(ApiResponse<ClienteDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ClienteDto>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<ClienteDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObtenerPorIdentificacion(string identificacion, CancellationToken cancellationToken)
    {
        var resultado = await _clienteService.ObtenerPorIdentificacionAsync(identificacion, cancellationToken);

        if (!resultado.Exito)
        {
            if (resultado.Mensaje.Contains("obligatorio", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(resultado);
            }
            return NotFound(resultado);
        }

        return Ok(resultado);
    }
}
