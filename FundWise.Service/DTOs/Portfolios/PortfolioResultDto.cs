using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class PortfolioResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public User User { get; set; } = default!;
    public List<AssetResultDto> Assets { get; set; } = default!;
}
