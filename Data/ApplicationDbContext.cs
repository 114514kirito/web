using Microsoft.EntityFrameworkCore;
using sujiayang.Models;

namespace sujiayang.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ContactMessage>(entity =>
        {
            entity.Property(message => message.CreatedAtUtc)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}
