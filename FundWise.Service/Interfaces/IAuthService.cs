namespace FundWise.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(string phone, string password);
}
