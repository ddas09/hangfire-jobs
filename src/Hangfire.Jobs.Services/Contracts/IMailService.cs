namespace Hangfire.Jobs.Services.Contracts;

public interface IMailService
{
    Task SendMail(string email);
}
