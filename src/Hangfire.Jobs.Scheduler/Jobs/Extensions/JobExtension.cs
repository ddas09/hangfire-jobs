using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Jobs.Scheduler.Jobs.Extensions;

public static class JobExtension
{
    public static void RegisterJobs(this IServiceCollection services)
    {
        services.AddSingleton<BillingJob>();
        services.AddSingleton<CleanupJob>();
    }
}