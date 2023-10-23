using ContactManagerApi.Infrastructure.Persistance.Repositories.Contacts;
using ContactManagerApi.Persistance;

using Microsoft.AspNetCore.Mvc.Versioning;

namespace ContactManagerApi.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public const string CorsPolicy = "CorsPolicy";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .ConfigureApiVersioning()
            .AddPersistance()
            .ConfigureCors()
            .ConfigureApiVersionExplorer()
            .ConfigureSwagger();
            
        
        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<ContactManagerDbContext>();
        services.AddScoped<IContactRepository, ContactRepository>();
        return services;
    }

    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy,
                builder => builder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });
        return services;
    }

    public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
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

        return services;
    }

    public static IServiceCollection ConfigureApiVersionExplorer(this IServiceCollection services) 
    {
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IServiceCollection ConfigureSwagger(this IServiceCollection services) 
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

        return services;
    }
}