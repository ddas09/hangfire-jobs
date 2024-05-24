using Hangfire.Jobs.DAL;
using Hangfire.Jobs.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Hangfire.Jobs.Services.Contracts;

namespace Hangfire.Jobs.Services;

public class BillingService : IBillingService
{
    private readonly HangfireApiContext _dbContext;

    public BillingService(HangfireApiContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task GenerateBillingEntries()
    {
        var users = await _dbContext.Users.ToListAsync();

        var billings = users.Select(user => new Billing
        {
            UserId = user.Id,
            Amount = CalculateBillingAmount(user),
            Date = DateTime.UtcNow
        });

        _dbContext.Billings.AddRange(billings);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine("Billing job completed");
    }

    private static decimal CalculateBillingAmount(User user)
    {
        return user.Id * 10.0m;
    }
}