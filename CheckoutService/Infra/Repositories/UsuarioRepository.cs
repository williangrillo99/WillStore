using Domain.Interface;
using Infra.HttpClients;

namespace Infra.Repositories;

public sealed class UsuarioRepository(IUsuariosServiceApi usuariosServiceApi) : IUsuarioRepository
{
    public async Task<int> RecuperarUsuariosPorIdAsync(int id)
    {
        var usuario = await usuariosServiceApi.ObterUsuarioAsync(id.ToString());
        
        return usuario;
    }
}