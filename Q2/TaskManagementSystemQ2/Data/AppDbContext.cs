using Microsoft.EntityFrameworkCore;
using TaskManagementSystemQ2.Model;

namespace TaskManagementSystemQ2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(b =>
        {
            b.HasKey(t => t.Id);
            b.Property(t => t.Title).IsRequired();
        });
    }
}
