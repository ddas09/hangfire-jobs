namespace Hangfire.Jobs.Core.JobActivator;

public class HangfireJobActivator : Hangfire.JobActivator
{
    private readonly IServiceProvider _serviceProvider;

    public HangfireJobActivator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider 
            ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public override object ActivateJob(Type jobType)
    {
        return _serviceProvider.GetService(jobType);
    }
}