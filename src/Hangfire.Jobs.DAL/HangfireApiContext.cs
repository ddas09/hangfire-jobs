using Hangfire.Jobs.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hangfire.Jobs.DAL;
public partial class HangfireApiContext : DbContext
{
    public HangfireApiContext()
    {
    }

    public HangfireApiContext(DbContextOptions<HangfireApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Billing>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Billings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Billings_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
