using ContactManagerApi.Application;
using ContactManagerApi.Infrastructure;

using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddInfrastructure();
    builder.Services.AddApplication();
    builder.Services.AddControllers();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddEndpointsApiExplorer();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
    }
    else
    {
        app.UseHttpsRedirection();
    }

    app.UseCors(InfrastructureDependencyInjection.CorsPolicy);
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
