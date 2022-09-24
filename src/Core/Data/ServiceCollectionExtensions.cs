using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CI.Core.Data.Contexts.EF;

namespace CI.Core.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<EFContext>(x => x.UseNpgsql(connectionString));
        }
    }
}