namespace Hangfire.Jobs.Services.Contracts;

public interface IUserService
{
    Task<bool> UserExists(string email);

    Task RegisterUser(string email);
}
