using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyGallery.Core.Domain.Helper.Extensions;

namespace MyGallery.Core.Domain.Middleware;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var httpException = ex.HttpMap();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpException.StatusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(httpException, new JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull }));
        }
    }
}