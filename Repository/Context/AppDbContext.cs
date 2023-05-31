using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>? Users { get; set; }
    public DbSet<UserStatus>? UserStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserStatus>()
            .HasData(Enum.GetValues(typeof(Entities.Enums.UserStatus))
                .Cast<Entities.Enums.UserStatus>().Select(userStatus =>
                    new UserStatus { Id = userStatus, Name = userStatus.ToString() }));
    }
}