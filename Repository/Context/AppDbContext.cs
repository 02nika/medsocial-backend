using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<UserStatus>? UserStatuses { get; set; }
    public DbSet<City>? Cities { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Gender>? Genders { get; set; }
    public DbSet<Language>? Languages { get; set; }
    public DbSet<Timezone>? Timezones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserStatus>()
            .HasData(Enum.GetValues(typeof(Entities.Models.Enums.UserStatus))
                .Cast<Entities.Models.Enums.UserStatus>().Select(userStatus =>
                    new UserStatus { Id = userStatus, Name = userStatus.ToString() }));

        modelBuilder.Entity<Gender>()
            .HasData(Enum.GetValues(typeof(Entities.Models.Enums.Gender))
                .Cast<Entities.Models.Enums.Gender>().Select(gender =>
                    new Gender { Id = gender, Name = gender.ToString() }));
        
        modelBuilder.Entity<Language>()
            .HasData(Enum.GetValues(typeof(Entities.Models.Enums.Language))
                .Cast<Entities.Models.Enums.Language>().Select(language =>
                    new Language { Id = language, Name = language.ToString() }));
    }
}