using FundWise.Service.DTOs;
using FundWise.Service.Interfaces.Commons;

namespace FundWise.Service.Interfaces;

public interface IPortfolioService : IServiceInterface<PortfolioCreationDto, PortfolioUpdateDto, PortfolioResultDto>
{
}
