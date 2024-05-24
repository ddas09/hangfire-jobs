using Hangfire.Jobs.DAL;
using Microsoft.EntityFrameworkCore;
using Hangfire.Jobs.Services.Contracts;

namespace Hangfire.Jobs.Services;

public class CleanupService : ICleanupService
{
    private readonly HangfireApiContext _dbContext;

    public CleanupService(HangfireApiContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CleanupOldEntries()
    {
        var oldEntries = await _dbContext.Billings.OrderBy(e => e.Id).Take(10).ToListAsync();

        _dbContext.Billings.RemoveRange(oldEntries);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine("Cleanup job completed");
    }
}