using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class CheckoutController : ControllerBase
{
    private readonly ILogger<CheckoutController> _logger;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPedidoRepository _pedidoRepository;

    public CheckoutController(
        ILogger<CheckoutController> logger, 
        IUsuarioRepository usuarioRepository,
        IPedidoRepository pedidoRepository)
    {
        _logger = logger;
        _usuarioRepository = usuarioRepository;
        _pedidoRepository = pedidoRepository;
    }

    [HttpGet(Name = "Checkout")]
    public async Task<IActionResult> Checkout()
    {
        var pedido = await _pedidoRepository.RecuperarPedidoPorIdAsync(1);
        var usuario = await _usuarioRepository.RecuperarUsuariosPorIdAsync(1);

        return Ok();
    }
}