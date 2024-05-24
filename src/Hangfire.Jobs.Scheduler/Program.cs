using Hangfire.Jobs.Scheduler;
using Hangfire.Jobs.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Hangfire.Jobs.Scheduler.Jobs.Extensions;
using Microsoft.Extensions.DependencyInjection;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("HangfireJobsConnection");

IServiceCollection services = new ServiceCollection();

// Add Hangfire
services.RegisterHangfire(connectionString);

// Register services
services.RegisterCoreServices();

// Register jobs to DI container
services.RegisterJobs();

services.AddSingleton<JobScheduler>();

using (var serviceProvider = services.BuildServiceProvider())
{
    var scheduler = serviceProvider.GetRequiredService<JobScheduler>();
    scheduler.ScheduleJobs();

    Console.WriteLine("Hangfire Scheduler started. Press any key to exit...");
    Console.ReadKey();
}