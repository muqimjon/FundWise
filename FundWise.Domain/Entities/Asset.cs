namespace FundWise.Domain.Entities;

public class Asset : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MarketValue { get; set; }
    public decimal RiskLevel { get; set; }

    public long PortfolioId { get; set; }
    public Portfolio Portfolio { get; set; } = default!;

    public ICollection<Transaction> Transactions { get; set; } = default!;
}
