using System.Linq.Expressions;

namespace Hangfire.Jobs.Core.Services.Contracts;

public interface IBackgroundJobService
{
    void RegisterFireAndForgetJob<T>(Expression<Func<T, Task>> methodCall);

    void RegisterRecurringJobs<T>(string jobId, Expression<Func<T, Task>> methodCall, string cronExpression);
}