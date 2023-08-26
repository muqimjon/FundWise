using AutoMapper;
using FundWise.Service.DTOs;
using FundWise.Domain.Entities;
using FundWise.Service.Exceptions;
using FundWise.Service.Extensions;
using FundWise.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using FundWise.Domain.Configurations;
using FundWise.DataAccess.IRepositories;

namespace FundWise.Service.Services;

public class InvestmentStrategyService : IInvestmentStrategyService
{
    private readonly IRepository<InvestmentStrategy> repository;
    private readonly IMapper mapper;

    public InvestmentStrategyService(IRepository<InvestmentStrategy> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<InvestmentStrategyResultDto> AddAsync(InvestmentStrategyCreationDto dto)
    {
        var mappedInvestmentStrategy = mapper.Map<InvestmentStrategy>(dto);
        await repository.CreateAsync(mappedInvestmentStrategy);
        await repository.SaveAsync();

        var result = mapper.Map<InvestmentStrategyResultDto>(mappedInvestmentStrategy);
        return result;
    }

    public async Task<InvestmentStrategyResultDto> ModifyAsync(InvestmentStrategyUpdateDto dto)
    {
        InvestmentStrategy existInvestmentStrategy = await repository.SelectAsync(u => u.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This InvestmentStrategy is not found with ID: {dto.Id}");

        mapper.Map(dto, existInvestmentStrategy);
        repository.Update(existInvestmentStrategy);
        await repository.SaveAsync();

        var result = mapper.Map<InvestmentStrategyResultDto>(existInvestmentStrategy);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        InvestmentStrategy existInvestmentStrategy = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This InvestmentStrategy is not found with ID: {id}");

        await repository.DeleteAsync(e => e.Id == id);
        await repository.SaveAsync();

        var result = mapper.Map<InvestmentStrategyResultDto>(existInvestmentStrategy);
        return true;
    }

    public async Task<InvestmentStrategyResultDto> RetrieveByIdAsync(long id)
    {
        InvestmentStrategy existInvestmentStrategy = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This InvestmentStrategy is not found with ID: {id}");

        var result = mapper.Map<InvestmentStrategyResultDto>(existInvestmentStrategy);
        return result;
    }

    public async Task<IEnumerable<InvestmentStrategyResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var InvestmentStrategys = await repository.SelectAll().ToPaginate(@params).ToListAsync();
        var result = mapper.Map<IEnumerable<InvestmentStrategyResultDto>>(InvestmentStrategys);
        return result;
    }
}
