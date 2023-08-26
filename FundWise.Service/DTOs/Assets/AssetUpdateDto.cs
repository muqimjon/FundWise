namespace FundWise.Service.DTOs;

public class AssetUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal MarketValue { get; set; }
    public decimal RiskLevel { get; set; }
    public long PortfolioId { get; set; }
}
