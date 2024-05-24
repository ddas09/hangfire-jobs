using Hangfire.Storage;
using System.Linq.Expressions;
using Hangfire.Jobs.Core.Services.Contracts;

namespace Hangfire.Jobs.Core.Services;

public class BackgroundJobService : IBackgroundJobService
{
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private static readonly List<RecurringJobDto> _recurringJobs = JobStorage.Current.GetConnection().GetRecurringJobs();

    public BackgroundJobService(IRecurringJobManager recurringJobManager, IBackgroundJobClient backgroundJobClient)
    {
        _recurringJobManager = recurringJobManager;
        _backgroundJobClient = backgroundJobClient;
    }

    public void RegisterFireAndForgetJob<T>(Expression<Func<T, Task>> methodCall)
    {
        _backgroundJobClient.Enqueue<T>(methodCall);
    }

    public void RegisterRecurringJobs<T>(string jobId, Expression<Func<T, Task>> methodCall, string cronExpression)
    {
        if (!JobExists(jobId))
        {
            _recurringJobManager.AddOrUpdate<T>(jobId, methodCall, cronExpression);
        }
    }

    private static bool JobExists(string jobId) => _recurringJobs.Any(job => job.Id == jobId);
}