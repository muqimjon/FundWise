namespace FundWise.Service.DTOs;

public class PortfolioUpdateDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long UserId { get; set; }
}