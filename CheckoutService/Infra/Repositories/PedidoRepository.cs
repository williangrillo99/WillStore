using Domain.Interface;
using Infra.HttpClients;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public sealed class PedidoRepository(IPedidosServiceApi pedidosServiceApi, ILogger<PedidoRepository> logger)
    : IPedidoRepository
{
    public async Task<int> RecuperarPedidoPorIdAsync(int id)
    {
        logger.LogInformation("{Service} - Chamando PedidoApi", "CheckoutService");

        var respose = await pedidosServiceApi.ObterPedidoPorIdAsync(id.ToString());

        logger.LogInformation("{Service} - Resposta PedidoApi - Sucesso", "CheckoutService");

        return respose;
    }
}