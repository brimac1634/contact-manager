using System.Reflection;

using ContactManagerApi.Entities;

using Microsoft.EntityFrameworkCore;

namespace ContactManagerApi.Persistance;

public class ContactManagerDbContext : DbContext
{
    private const string _databaseName = "ContactManagerDatabase";

    protected readonly IConfiguration Configuration;
    protected readonly IWebHostEnvironment WebHostEnvironment;

    public ContactManagerDbContext(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
        Configuration = configuration;
        WebHostEnvironment = webHostEnvironment;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString(_databaseName));
            optionsBuilder.LogTo(Console.WriteLine);

            if (WebHostEnvironment.IsDevelopment()) {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
    }

    public DbSet<Contact> Contacts { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Contact>();
            // .HasMany<Device>(u => u.Devices)
            // .WithOne(d => d.User)
            // .HasForeignKey(d => d.UserId)
            // .OnDelete(DeleteBehavior.Cascade);
    }
}