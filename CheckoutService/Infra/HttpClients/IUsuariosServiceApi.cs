using Refit;

namespace Infra.HttpClients;

public interface IUsuariosServiceApi
{
    [Get("/usuarios/recuperar/{usuarioId}")]
    Task<int> ObterUsuarioAsync(string usuarioId);
}