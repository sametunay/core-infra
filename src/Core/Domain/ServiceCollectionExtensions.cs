using Microsoft.Extensions.DependencyInjection;
using MyGallery.Core.Domain.Middleware;

namespace MyGallery.Core.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExceptionHandlerService(this IServiceCollection services)
    {
        services.AddSingleton(typeof(ExceptionHandlerMiddleware));
        
        return services;   
    }
}