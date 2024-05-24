using Hangfire.Jobs.Core.Services;
using Hangfire.Jobs.Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Jobs.Core.Extensions;

public static class ServiceExtension
{
    public static void RegisterCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IBackgroundJobService, BackgroundJobService>();
    }
}