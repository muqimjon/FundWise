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

public class FinancialDataService : IFinancialDataService
{
    private readonly IRepository<FinancialData> repository;
    private readonly IMapper mapper;

    public FinancialDataService(IRepository<FinancialData> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<FinancialDataResultDto> AddAsync(FinancialDataCreationDto dto)
    {
        var mappedFinancialData = mapper.Map<FinancialData>(dto);
        await repository.CreateAsync(mappedFinancialData);
        await repository.SaveAsync();

        var result = mapper.Map<FinancialDataResultDto>(mappedFinancialData);
        return result;
    }

    public async Task<FinancialDataResultDto> ModifyAsync(FinancialDataUpdateDto dto)
    {
        FinancialData existFinancialData = await repository.SelectAsync(u => u.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This FinancialData is not found with ID: {dto.Id}");

        mapper.Map(dto, existFinancialData);
        repository.Update(existFinancialData);
        await repository.SaveAsync();

        var result = mapper.Map<FinancialDataResultDto>(existFinancialData);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        FinancialData existFinancialData = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This FinancialData is not found with ID: {id}");

        await repository.DeleteAsync(e => e.Id == id);
        await repository.SaveAsync();

        var result = mapper.Map<FinancialDataResultDto>(existFinancialData);
        return true;
    }

    public async Task<FinancialDataResultDto> RetrieveByIdAsync(long id)
    {
        FinancialData existFinancialData = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This FinancialData is not found with ID: {id}");

        var result = mapper.Map<FinancialDataResultDto>(existFinancialData);
        return result;
    }

    public async Task<IEnumerable<FinancialDataResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var FinancialInformation = await repository.SelectAll().ToPaginate(@params).ToListAsync();
        var result = mapper.Map<IEnumerable<FinancialDataResultDto>>(FinancialInformation);
        return result;
    }
}
