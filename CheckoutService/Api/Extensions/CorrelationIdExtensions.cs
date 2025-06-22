using CorrelationId.DependencyInjection;

namespace Api.Extensions;

public static class CorrelationIdExtensions
{
    private const string CorrelationIdHeaderName = "x-correlation-id";

    public static IServiceCollection AddCorrelationIdConfiguration(this IServiceCollection services)
    {
        services.AddDefaultCorrelationId(options =>
        {
            options.EnforceHeader = false;                      // Se 'true', obriga que toda requisição já venha com CorrelationId no header; caso contrário, retorna erro 400.
            options.RequestHeader = CorrelationIdHeaderName;    // Nome do header esperado na requisição (ex: x-correlation-id).
            options.ResponseHeader = CorrelationIdHeaderName;   // Nome do header que será enviado na resposta.
            options.IncludeInResponse = true;                   // Inclui o CorrelationId no header da resposta.
            options.CorrelationIdGenerator = () => Guid.NewGuid().ToString(); // Função para gerar o CorrelationId quando não vem na requisição.
            options.AddToLoggingScope = true;                   // Adiciona o CorrelationId automaticamente ao contexto de log.
            // options.IgnoreRequestHeader = true;              // Se ativar, sempre gera um novo CorrelationId (mesmo que venha um no header).
            // options.LoggingScopeKey = "correlation-id";      // Permite customizar o nome do campo que aparece no log.
            // options.UpdateTraceIdentifier = true;            // Atualiza o TraceIdentifier interno do ASP.NET Core (opcional).
        });

        return services;
    }
}