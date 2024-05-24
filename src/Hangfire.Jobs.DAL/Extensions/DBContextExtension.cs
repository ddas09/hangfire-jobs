using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hangfire.Jobs.DAL.Extensions;

public static class DBContextExtension
{
    public static void RegisterDBContext(this IServiceCollection services, string? connection)
    {
        if (string.IsNullOrWhiteSpace(connection))
        {
            throw new ArgumentNullException(nameof(connection));
        }

        services.AddDbContext<HangfireApiContext>(options =>
        {
            options.UseSqlServer(connection);
        });
    }
}