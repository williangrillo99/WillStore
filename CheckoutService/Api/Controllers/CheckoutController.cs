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
        var pedidoRandom = Random.Shared.Next(1, 100);
        var usuarioRandom = Random.Shared.Next(1, 100);

        _logger.LogInformation(
            "{Service} - Request - UsuarioId: {UsuarioId} - PedidoId: {PedidoId}",
            "CheckoutService", usuarioRandom, pedidoRandom);

        var pedidoId = await _pedidoRepository.RecuperarPedidoPorIdAsync(pedidoRandom);
        var usuarioId = await _usuarioRepository.RecuperarUsuariosPorIdAsync(usuarioRandom);

        _logger.LogInformation(
            "{Service} - " + "Retorno: UsuarioId: {usuarioId} - PedidoId: {pedidoId}",
            "CheckoutService", usuarioId, pedidoId);

        return Ok();
    }
}