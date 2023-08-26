using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class TransactionUpdateDto
{
    public long Id { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public ActionType Action { get; set; }
    public int AssetId { get; set; }
}
