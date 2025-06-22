using Domain.Interface;
using Infra.HttpClients;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public sealed class UsuarioRepository(IUsuariosServiceApi usuariosServiceApi, ILogger<UsuarioRepository> logger)
    : IUsuarioRepository
{
    public async Task<int> RecuperarUsuariosPorIdAsync(int id)
    {
        logger.LogInformation("{Service}- Chamando UsuarioApi: {Id} - {Class} - {Method}",
            "CheckoutService",
            id,
            nameof(UsuarioRepository),
            nameof(RecuperarUsuariosPorIdAsync));

        var usuario = await usuariosServiceApi.ObterUsuarioAsync(id.ToString());

        logger.LogInformation("{Service}- Resposta UsuarioApi - Sucesso - Id:{Id} - {Class} - {Method}",
            "CheckoutService",
            id,
            nameof(UsuarioRepository),
            nameof(RecuperarUsuariosPorIdAsync));

        return usuario;
    }
}