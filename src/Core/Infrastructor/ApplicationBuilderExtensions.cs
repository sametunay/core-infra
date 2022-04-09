using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyGallery.Core.Data.Contexts.EF;

namespace MyGallery.Core.Infrastructor;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder ExecuteMigration(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var databaseContext = scope.ServiceProvider.GetRequiredService<EFContext>();
            databaseContext.Database.Migrate();
        }

        return app;
    }
}