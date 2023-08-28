using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class AssetResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MarketValue { get; set; }
    public decimal RiskLevel { get; set; }
    public Portfolio Portfolio { get; set; } = default!;
    public ICollection<Transaction> Transactions { get; set; } = default!;
}
