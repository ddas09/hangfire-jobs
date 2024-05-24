using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Jobs.Core.Extensions;

public static class HangfireExtension
{
    public static void RegisterHangfire(this IServiceCollection services, string? connection)
    {
        if (string.IsNullOrWhiteSpace(connection))
        {
            throw new ArgumentNullException(nameof(connection));
        }
        
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connection));
    }

    public static void UseCustomHangfireDashboard(this IApplicationBuilder app)
    {
        app.UseHangfireDashboard();
    }
}