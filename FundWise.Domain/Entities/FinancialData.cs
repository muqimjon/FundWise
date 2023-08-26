namespace FundWise.Domain.Entities;

public class FinancialData : Auditable
{
    public decimal StockIndex { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal InterestRate { get; set; }
}