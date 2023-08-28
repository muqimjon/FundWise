using FundWise.DataAccess.IRepositories;
using FundWise.DataAccess.Repositories;
using FundWise.Service.Interfaces;
using FundWise.Service.Mappers;
using FundWise.Service.Services;

namespace FundWise.Web.Extensions;

public static class ServicesCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IPortfolioService, PortfolioService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IFinancialDataService, FinancialDataService>();
        services.AddScoped<IInvestmentStrategyService, InvestmentStrategyService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
