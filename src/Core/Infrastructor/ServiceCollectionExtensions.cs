using Microsoft.Extensions.DependencyInjection;
using CI.Core.Data;
using CI.Core.Infrastructor.Repositories.Implementation;
using CI.Core.Infrastructor.Repositories.Interfaces;
using CI.Core.Infrastructor.UnitOfWork;

namespace CI.Core.Infrastructor
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