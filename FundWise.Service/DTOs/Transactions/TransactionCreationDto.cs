using FundWise.Domain.Entities;

namespace FundWise.Service.DTOs;

public class TransactionCreationDto
{
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public ActionType Action { get; set; }
    public int AssetId { get; set; }
}