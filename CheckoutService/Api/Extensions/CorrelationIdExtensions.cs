using CorrelationId.DependencyInjection;

namespace Api.Extensions;

public static class CorrelationIdExtensions
{
    private const string CorrelationIdHeaderName = "x-correlation-id";

    public static IServiceCollection AddCorrelationIdConfiguration(this IServiceCollection services)
    {
        
        services.AddDefaultCorrelationId(options =>
        {
            options.EnforceHeader = true;
            options.RequestHeader = CorrelationIdHeaderName;
            options.ResponseHeader = CorrelationIdHeaderName;
            options.IncludeInResponse = true;
            // options.IgnoreRequestHeader = true;
            // options.LoggingScopeKey = "correlation-id";
            // options.UpdateTraceIdentifier = true;
            options.AddToLoggingScope = true;
        });

        return services;
    }
}