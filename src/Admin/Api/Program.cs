using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using MyGallery.Admin.Application;
using MyGallery.Core.Domain;
using MyGallery.Core.Domain.Middleware;
using MyGallery.Core.Domain.Options;
using MyGallery.Core.Infrastructor;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => SetApiInfo(options));

builder.Services.AddInfrastructor(builder.Configuration.GetSection(nameof(PsglOptions)).Get<PsglOptions>().ConnectionString);
builder.Services.AddAdminApplication();
builder.Services.AddOptions<HelpOptions>(builder.Configuration.GetSection(nameof(HelpOptions)).Value);
builder.Services.AddExceptionHandlerService();

SetOption<HelpOptions>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ExecuteMigration();
}

app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


#region Private Methods

void SetOption<TOption>() where TOption : class
{
    builder.Services.AddOptions<TOption>(builder.Configuration.GetSection(typeof(TOption).Name).Value);
}

void SetApiInfo(SwaggerGenOptions options)
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "MyGallery Admin",
        Description = "Basit bir crud api.",
        TermsOfService = new Uri("https://support@mygallery.com"),
        Contact = new OpenApiContact()
        {
            Email = "dev.sametunay@gmail.com",
            Url = new Uri("https://sametunay.com.tr"),
            Name = "Samet Unay"
        },
        License = new OpenApiLicense()
        {
            Name = "MIT LICENCE",
            Url = new Uri("https://mit.licence/mygallery")
        }
    });
}

#endregion
