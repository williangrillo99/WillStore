using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class PedidosController : ControllerBase
{
    private readonly ILogger<PedidosController> _logger;

    public PedidosController(ILogger<PedidosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Recuperar/{pedidoId}")]
    public ActionResult<string> Get(string pedidoId)
    {
        // _logger.LogInformation("{service} - Pedido Solicitado: {pedidoId}", "PedidosService", pedidoId);
        return Ok(pedidoId);
    }
}