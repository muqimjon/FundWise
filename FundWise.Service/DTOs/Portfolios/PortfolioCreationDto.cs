using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class PortfolioCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long UserId { get; set; }
}
