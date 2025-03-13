using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using SuperTaskBowl.Models;


namespace SuperTaskBowl.Data;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);

        modelBuilder.Entity<TaskItem>()
            .Property(t => t.Description)
            .HasMaxLength(1000);
    }
}
