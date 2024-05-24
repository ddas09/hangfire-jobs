using Hangfire;
using Hangfire.Jobs.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Hangfire.Jobs.Core.JobActivator;
using Hangfire.Jobs.Services.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("HangfireJobsConnection");
GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

IServiceCollection services = new ServiceCollection();

// Register DbContext
services.RegisterDBContext(configuration.GetConnectionString("HangfireApiConnection"));

// Register services
services.RegisterServices();

// Build the service provider
using (var serviceProvider = services.BuildServiceProvider())
{
    // Configure Hangfire to use the same service provider
    GlobalConfiguration.Configuration.UseActivator(new HangfireJobActivator(serviceProvider));

    using (var server = new BackgroundJobServer())
    {
        Console.WriteLine("Hangfire Server started. Press any key to exit...");
        Console.ReadKey();
    }
}