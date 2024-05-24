using Hangfire.Jobs.Services.Contracts;
using Hangfire.Jobs.Core.Services.Contracts;
using Hangfire.Jobs.Scheduler.Jobs.Contracts;

namespace Hangfire.Jobs.Scheduler.Jobs;

public class CleanupJob : IBackgroundJob
{
    private const string CleanupJobId = "CleanupRecurringJob";
    private readonly IBackgroundJobService _backgroundJobService;

    public CleanupJob(IBackgroundJobService backgroundJobService)
    {
        _backgroundJobService = backgroundJobService;
    }

    public void Schedule()
    {
        _backgroundJobService
            .RegisterRecurringJobs<ICleanupService>(CleanupJobId, bs => bs.CleanupOldEntries(), Cron.MinuteInterval(2));
    }
}