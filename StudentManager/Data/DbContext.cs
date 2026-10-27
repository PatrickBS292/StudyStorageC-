using Microsoft.EntityFrameworkCore;
using StudentManager.Models;

namespace StudentManager.Data;

public class AppDbContext : DbContext {

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }

    public DbSet<Student> Student => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity => {
            entity.Property(p => p.Name).HasMaxLength(100);
            entity.Property(p => p.Education).HasMaxLength(100);
            entity.Property(p => p.Email).HasMaxLength(100);
            entity.Property(p => p.Semester).IsRequired();
        });
    }
}