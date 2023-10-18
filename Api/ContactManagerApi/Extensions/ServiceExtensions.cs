using ContactManagerApi.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ContactManagerApi.Extensions;

public static class ServicesExtensions
{
    public const string CorsPolicy = "CorsPolicy";
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder => builder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });
    }

    public static void ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;
            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                            new HeaderApiVersionReader("x-api-version"),
                                                            new MediaTypeApiVersionReader("x-api-version"));
        });
    }

    public static void ConfigureApiVersionExplorer(this IServiceCollection services) 
    {
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services) 
    {
        services.AddSwaggerGen(options => {
            // options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            // {
            //     Description = "Standard Authorization header using Bearer scheme (\"Bearer {token}\")",
            //     In = ParameterLocation.Header,
            //     Name = "Authorization",
            //     Type = SecuritySchemeType.ApiKey
            // });

            // options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}