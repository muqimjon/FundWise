using FundWise.Domain.Entities;
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
    }
}
