using Microsoft.AspNetCore.Builder;
using MyGallery.Core.Domain.Middleware;

namespace MyGallery.Core.Domain;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}