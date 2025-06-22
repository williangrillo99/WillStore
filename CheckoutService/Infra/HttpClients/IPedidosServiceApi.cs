using Refit;

namespace Infra.HttpClients;

public interface IPedidosServiceApi
{
    [Get("/pedidos/recuperar/{pedidoId}")]
    Task<int> ObterPedidoPorIdAsync(string pedidoId);
}