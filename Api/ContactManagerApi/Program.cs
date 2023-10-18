using ContactManagerApi.Extensions;

using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.ConfigureApiVersioning();
    builder.Services.AddControllers();
    // builder.Services.AddDbContext<ContactManagerDbContext>();
    builder.Services.AddHttpContextAccessor();

    builder.Services.ConfigureCors();
    builder.Services.ConfigureApiVersionExplorer();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.ConfigureSwagger();
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

    app.UseCors(ServicesExtensions.CorsPolicy);
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
