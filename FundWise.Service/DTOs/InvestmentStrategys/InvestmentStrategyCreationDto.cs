using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class InvestmentStrategyCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public RiskLevel MinRiskLevel { get; set; }
    public decimal MinExpectedReturn { get; set; }
}
