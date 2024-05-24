namespace Hangfire.Jobs.Services.Contracts;

public interface IBillingService
{
    Task GenerateBillingEntries();
}