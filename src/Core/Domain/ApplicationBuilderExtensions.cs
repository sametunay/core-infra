using Microsoft.AspNetCore.Builder;
using CI.Core.Domain.Middleware;

namespace CI.Core.Domain;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}