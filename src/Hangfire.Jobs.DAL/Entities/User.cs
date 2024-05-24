namespace Hangfire.Jobs.DAL.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();
}
