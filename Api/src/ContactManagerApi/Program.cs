using ContactManagerApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.ConfigureApiVersioning();
    builder.Services.AddControllers();
    // builder.Services.AddDbContext<ContactManagerDbContext>();
    builder.Services.AddHttpContextAccessor();

    // builder.Services.AddSwaggerGen();

    builder.Services.ConfigureCors();
    builder.Services.AddEndpointsApiExplorer();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();
    app.UseCors(ServicesExtensions.CorsPolicy);
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
