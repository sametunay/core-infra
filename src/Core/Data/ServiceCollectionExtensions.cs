using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGallery.Core.Data.Contexts.EF;

namespace MyGallery.Core.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<EFContext>(x => x.UseNpgsql(connectionString));
        }
    }
}