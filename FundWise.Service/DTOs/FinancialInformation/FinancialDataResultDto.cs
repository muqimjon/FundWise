namespace FundWise.Service.DTOs;

public class FinancialDataResultDto
{
    public long Id { get; set; }
    public decimal StockIndex { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal InterestRate { get; set; }
}
