using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(ILogger<UsuariosController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Recuperar/{usuarioId}")]
    public ActionResult<string> Get(string usuarioId)
    {
        _logger.LogInformation(
            "UsuariosService: {class}-{method}-{usuarioId}",
            nameof(UsuariosController),
            nameof(Get),
            usuarioId);
        
        return Ok(usuarioId);
    }
}