using Microsoft.Extensions.DependencyInjection;
using CI.Core.Data;
using CI.Core.Infrastructure.Repositories.Implementation;
using CI.Core.Infrastructure.Repositories.Interfaces;
using CI.Core.Infrastructure.UnitOfWork;

namespace CI.Core.Infrastructure
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

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            return services.AddRepositories().AddData(connectionString);
        }
    }
}