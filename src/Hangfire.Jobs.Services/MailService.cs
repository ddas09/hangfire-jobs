using Hangfire.Jobs.Services.Contracts;

namespace Hangfire.Jobs.Services;

public class MailService : IMailService
{
    public async Task SendMail(string email)
    {
        // Simulate a delay of 5 seconds
        await Task.Delay(5000);

        Console.WriteLine($"Email sent to {email}.");
    }
}