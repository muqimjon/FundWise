using AutoMapper;
using FundWise.Domain.Entities;
using FundWise.Service.DTOs;

namespace FundWise.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<User, UserResultDto>();
        CreateMap<UserCreationDto, User>();
        CreateMap<UserUpdateDto, User>();

        // Transaction
        CreateMap<Transaction, TransactionResultDto>();
        CreateMap<TransactionCreationDto, Transaction>();
        CreateMap<TransactionUpdateDto, Transaction>();

        // Portfolio
        CreateMap<Portfolio, PortfolioResultDto>();
        CreateMap<PortfolioCreationDto, Portfolio>();
        CreateMap<PortfolioUpdateDto, Portfolio>();

        // Asset
        CreateMap<Asset, AssetResultDto>();
        CreateMap<AssetCreationDto, Asset>();
        CreateMap<AssetUpdateDto, Asset>();

        // FinancialData
        CreateMap<FinancialData, FinancialDataResultDto>();
        CreateMap<FinancialDataCreationDto, FinancialData>();
        CreateMap<FinancialDataUpdateDto, FinancialData>();

        // InvestmentStrategy
        CreateMap<InvestmentStrategy, InvestmentStrategyResultDto>();
        CreateMap<InvestmentStrategyCreationDto, InvestmentStrategy>();
        CreateMap<InvestmentStrategyUpdateDto, InvestmentStrategy>();
    }
}
