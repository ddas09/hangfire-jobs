using Hangfire.Jobs.Scheduler.Jobs;

namespace Hangfire.Jobs.Scheduler;

public class JobScheduler
{
    private readonly BillingJob _billingJob;
    private readonly CleanupJob _cleanupJob;

    public JobScheduler(BillingJob billingJob, CleanupJob cleanupJob)
    {
        _billingJob = billingJob;
        _cleanupJob = cleanupJob;
    }

    public void ScheduleJobs()
    {
        _billingJob.Schedule(); 
        _cleanupJob.Schedule(); 
    }
}