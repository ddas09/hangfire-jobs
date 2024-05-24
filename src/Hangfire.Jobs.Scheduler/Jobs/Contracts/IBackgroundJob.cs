namespace Hangfire.Jobs.Scheduler.Jobs.Contracts;

public interface IBackgroundJob
{
    void Schedule();
}