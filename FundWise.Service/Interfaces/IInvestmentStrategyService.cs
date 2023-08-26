using FundWise.Service.DTOs;
using FundWise.Service.Interfaces.Commons;

namespace FundWise.Service.Interfaces;

public interface IInvestmentStrategyService : IServiceInterface<InvestmentStrategyCreationDto, InvestmentStrategyUpdateDto, InvestmentStrategyResultDto>
{
}
