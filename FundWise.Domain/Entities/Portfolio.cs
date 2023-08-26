namespace FundWise.Domain.Entities;

public class Portfolio : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public long UserId { get; set; }
    public User User { get; set; } = default!;

    public List<Asset> Assets { get; set; } = default!;
}
