using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class TransactionResultDto
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public ActionType Action { get; set; }
    public AssetResultDto Asset { get; set; } = default!;
}
