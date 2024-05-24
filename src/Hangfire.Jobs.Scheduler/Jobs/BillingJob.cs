using Hangfire.Jobs.Services.Contracts;
using Hangfire.Jobs.Core.Services.Contracts;
using Hangfire.Jobs.Scheduler.Jobs.Contracts;

namespace Hangfire.Jobs.Scheduler.Jobs;

public class BillingJob : IBackgroundJob
{
    private const string BillingJobId = "BillingRecurringJob";
    private readonly IBackgroundJobService _backgroundJobService;

    public BillingJob(IBackgroundJobService backgroundJobService)
    {
        _backgroundJobService = backgroundJobService;
    }

    public void Schedule()
    {
        _backgroundJobService
            .RegisterRecurringJobs<IBillingService>(BillingJobId, bs => bs.GenerateBillingEntries(), Cron.Minutely());
    }
}