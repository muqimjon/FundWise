using FundWise.Domain.Entities;
using FundWise.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace FundWise.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<FinancialData> FinancialInformation { get; set; }
    public DbSet<InvestmentStrategy> InvestmentStrategies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Asset)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 10,
                LastName = "Doe",
                FirstName = "John",
                DateOfBirth = new DateTime(1990, 5, 15).ToUniversalTime(),
                Email = "johndoe@example.com",
                Phone = "123-456-7890",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            },
            new User
            {
                Id = 20,
                LastName = "Smith",
                FirstName = "Emily",
                DateOfBirth = new DateTime(1985, 10, 25, 0, 0, 0).ToUniversalTime(),
                Email = "emilysmith@example.com",
                Phone = "987-654-3210",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            },
            new User
            {
                Id = 30,
                LastName = "Johnson",
                FirstName = "Michael",
                DateOfBirth = new DateTime(1978, 3, 8, 0,0,0).ToUniversalTime(),
                Email = "michaeljohnson@example.com",
                Phone = "555-123-4567",
                Password = "password",
                Role = UserRole.Admin,
                Portfolios = new List<Portfolio>()
            },
            new User
            {

                Id = 40,
                LastName = "Williams",
                FirstName = "Jessica",
                DateOfBirth = new DateTime(1995, 7, 12, 0, 0, 0).ToUniversalTime(),
                Email = "jessicawilliams@example.com",
                Phone = "111-222-3333",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            },
            new User
            {
                Id = 50,
                LastName = "Tursunov",
                FirstName = "Sanjar",
                DateOfBirth = new DateTime(1992, 9, 10, 0, 0, 0).ToUniversalTime(),
                Email = "sanjar@example.com",
                Phone = "998-91-234-56-78",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            },
            new User
            {
                Id = 60,
                LastName = "Tursunov",
                FirstName = "Sanjar",
                DateOfBirth = new DateTime(1992, 9, 10, 0, 0, 0).ToUniversalTime(),
                Email = "sanjar@example.com",
                Phone = "998-91-234-56-78",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            },
            new User
            {
                Id = 70,
                LastName = "Ismoilov",
                FirstName = "Umid",
                DateOfBirth = new DateTime(1993, 4, 5, 0, 0, 0).ToUniversalTime(),
                Email = "umid@example.com",
                Phone = "998-93-456-78-90",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            },
            new User
            {
                Id = 80,
                LastName = "Nazarov",
                FirstName = "Nodir",
                DateOfBirth = new DateTime(1991, 11, 15, 0, 0, 0).ToUniversalTime(),
                Email = "nodir@example.com",
                Phone = "998-94-567-89-01",
                Password = "password",
                Role = UserRole.User,
                Portfolios = new List<Portfolio>()
            }
            );
    }
}

