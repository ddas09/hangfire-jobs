namespace Hangfire.Jobs.Services.Contracts;

public interface ICleanupService
{
    Task CleanupOldEntries();
}