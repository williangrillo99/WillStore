using CorrelationId.HttpClient;
using Domain.Interface;
using Infra.HttpClients;
using Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Infra;

public static class DependecyInjection
{
    private const string UsuarioServiceApi = "UsuarioServiceApi";
    private const string PedidosServiceApi = "PedidosServiceApi";

    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        AddHttpUsuariosService(services);
        AddHttpPedidosService(services);
        return services;
    }

    private static void AddHttpUsuariosService(IServiceCollection services)
    {
        services.AddRefitClient<IUsuariosServiceApi>(null, UsuarioServiceApi)
            .ConfigureHttpClient(client => { client.BaseAddress = new Uri("https://localhost:7197"); })
            .AddCorrelationIdForwarding();
    }

    private static void AddHttpPedidosService(IServiceCollection services)
    {
        services.AddRefitClient<IPedidosServiceApi>(null, PedidosServiceApi)
            .ConfigureHttpClient(client => { client.BaseAddress = new Uri("https://localhost:7019"); })
            .AddCorrelationIdForwarding();
    }
}