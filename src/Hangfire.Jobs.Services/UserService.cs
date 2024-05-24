using Hangfire.Jobs.DAL;
using Hangfire.Jobs.DAL.Entities;
using Hangfire.Jobs.Services.Contracts;
using Hangfire.Jobs.Core.Services.Contracts;

namespace Hangfire.Jobs.Services;

public class UserService : IUserService
{
    private readonly HangfireApiContext _dbContext;
    private readonly IBackgroundJobService _backgroundJobService;

    public UserService(IBackgroundJobService backgroundJobService, HangfireApiContext dbContext)
    {
        _dbContext = dbContext;
        _backgroundJobService = backgroundJobService;
    }

    public async Task<bool> UserExists(string email)
    {
        return await Task.FromResult(_dbContext.Users.Any(u => u.Email == email));
    }

    public async Task RegisterUser(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Email cannot be empty.");
        }

        var user = new User { Email = email };
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        _backgroundJobService.RegisterFireAndForgetJob<IMailService>(ms => ms.SendMail(email));
    }
}
