namespace FundWise.Domain.Entities;

public class Transaction : Auditable
{
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public ActionType Action { get; set; }

    public long AssetId { get; set; }
    public Asset Asset { get; set; } = default!;
}
