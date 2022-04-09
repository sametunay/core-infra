using Microsoft.Extensions.DependencyInjection;
using MyGallery.UI.Application.Mapper;
using MyGallery.UI.Application.Services.Imlementation;
using MyGallery.UI.Application.Services.Interfaces;

namespace MyGallery.UI.Application;

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