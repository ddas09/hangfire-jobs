using Hangfire.Jobs.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Jobs.Services.Extensions;

public static class ServiceExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IBillingService, BillingService>();
        services.AddScoped<ICleanupService, CleanupService>();
    }
}