using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using CI.Admin.Application.Mapper.Profiles;

namespace CI.Admin.Application.Mapper;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddAdminMapper(this IServiceCollection services)
    {
        return services.AddAutoMapper(cfg => cfg.AddAdminProfiles());
    }

    public static IMapperConfigurationExpression AddAdminProfiles(this IMapperConfigurationExpression config)
    {
        config.AddProfile<CarProfile>();
        config.AddProfile<CarCategoryProfile>();
        config.AddProfile<BrandProfile>();

        return config;
    }
}