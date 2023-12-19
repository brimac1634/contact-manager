
using ContactManagerApi.Services.Contacts;

namespace ContactManagerApi.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IContactsService, ContactsService>();
        return services;
    }
}