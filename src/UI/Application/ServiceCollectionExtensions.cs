using Microsoft.Extensions.DependencyInjection;
using CI.UI.Application.Mapper;
using CI.UI.Application.Services.Imlementation;
using CI.UI.Application.Services.Interfaces;

namespace CI.UI.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUiApplication(this IServiceCollection services)
    {
        services.AddUIServices();
        services.AddUIMapper();
        
        return services;
    }

    public static IServiceCollection AddUIServices(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<ICarCategoryService, CarCategoryService>();
        services.AddScoped<IBrandService, BrandService>();

        return services;
    }
}