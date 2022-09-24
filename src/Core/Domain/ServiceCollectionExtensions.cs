using Microsoft.Extensions.DependencyInjection;
using CI.Core.Domain.Middleware;

namespace CI.Core.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExceptionHandlerService(this IServiceCollection services)
    {
        services.AddSingleton(typeof(ExceptionHandlerMiddleware));
        
        return services;   
    }
}