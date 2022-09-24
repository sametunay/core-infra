using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using CI.Admin.Application.Service.Implementation;
using CI.Admin.Application.Service.Interfaces;
using CI.Admin.Application.Mapper;
using CI.Admin.Application.Validations.Brand;

namespace CI.Admin.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAdminApplication(this IServiceCollection services)
        {
            services.AddAdminServices();
            services.AddAdminMapper();
            services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<CreateBrandValidator>());
            
            return services;
        }

        public static IServiceCollection AddAdminServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarCategoryService, CarCategoryService>();
            services.AddScoped<IBrandService, BrandService>();

            return services;
        }
    }
}