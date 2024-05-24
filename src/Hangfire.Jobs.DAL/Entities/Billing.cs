namespace Hangfire.Jobs.DAL.Entities;

public partial class Billing
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTime Date { get; set; }

    public virtual User User { get; set; } = null!;
}
