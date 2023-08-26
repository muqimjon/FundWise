namespace FundWise.Domain.Entities;

public class InvestmentStrategy : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RiskLevel MinRiskLevel { get; set; }
    public decimal MinExpectedReturn { get; set; }
}
