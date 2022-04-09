using Microsoft.Extensions.DependencyInjection;
using MyGallery.Core.Data;
using MyGallery.Core.Infrastructor.Repositories.Implementation;
using MyGallery.Core.Infrastructor.Repositories.Interfaces;
using MyGallery.Core.Infrastructor.UnitOfWork;

namespace MyGallery.Core.Infrastructor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarCategoryRepository, CarCategoryRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }

        public static IServiceCollection AddInfrastructor(this IServiceCollection services, string connectionString)
        {
            return services.AddRepositories().AddData(connectionString);
        }
    }
}