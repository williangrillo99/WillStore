using Domain.Interface;
using Infra.HttpClients;

namespace Infra.Repositories;

public sealed class PedidoRepository(IPedidosServiceApi pedidosServiceApi) : IPedidoRepository
{
    public async Task<int> RecuperarPedidoPorIdAsync(int id)
    {
        var respose = await pedidosServiceApi.ObterPedidoPorIdAsync(id.ToString());

        return respose;
    }
}