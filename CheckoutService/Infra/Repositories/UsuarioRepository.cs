using Domain.Interface;
using Infra.HttpClients;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public sealed class UsuarioRepository(IUsuariosServiceApi usuariosServiceApi, ILogger<UsuarioRepository> logger)
    : IUsuarioRepository
{
    public async Task<int> RecuperarUsuariosPorIdAsync(int id)
    {
        logger.LogInformation("{Service} - Chamando UsuarioApi - UsuarioId: {UsuarioId}", "CheckoutService", id);

        var usuario = await usuariosServiceApi.ObterUsuarioAsync(id.ToString());

        logger.LogInformation("{Service} - Resposta UsuarioApi - Sucesso", "CheckoutService");

        return usuario;
    }
}