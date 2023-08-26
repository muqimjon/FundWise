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

public class PortfolioService : IPortfolioService
{
    private readonly IRepository<Portfolio> repository;
    private readonly IRepository<User> userRepo;
    private readonly IMapper mapper;

    public PortfolioService(IRepository<Portfolio> repository, IMapper mapper, IRepository<User> userRepo)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.userRepo = userRepo;
    }

    public async Task<PortfolioResultDto> AddAsync(PortfolioCreationDto dto)
    {
        User existUser = await userRepo.SelectAsync(u => u.Id.Equals(dto.UserId))
            ?? throw new NotFoundException($"This user is not found with ID: {dto.UserId}");

        var mappedPortfolio = mapper.Map<Portfolio>(dto);
        await repository.CreateAsync(mappedPortfolio);
        await repository.SaveAsync();

        var result = mapper.Map<PortfolioResultDto>(mappedPortfolio);
        return result;
    }

    public async Task<PortfolioResultDto> ModifyAsync(PortfolioUpdateDto dto)
    {
        Portfolio existPortfolio = await repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This Portfolio is not found with ID: {dto.Id}");

        User existUser = await userRepo.SelectAsync(u => u.Id.Equals(dto.UserId))
            ?? throw new NotFoundException($"This user is not found with ID: {dto.UserId}");

        mapper.Map(dto, existPortfolio);
        repository.Update(existPortfolio);
        await repository.SaveAsync();

        var result = mapper.Map<PortfolioResultDto>(existPortfolio);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        Portfolio existPortfolio = await repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This Portfolio is not found with ID: {id}");

        await repository.DeleteAsync(e => e.Id == id);
        await repository.SaveAsync();

        var result = mapper.Map<PortfolioResultDto>(existPortfolio);
        return true;
    }

    public async Task<PortfolioResultDto> RetrieveByIdAsync(long id)
    {
        Portfolio existPortfolio = await repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This Portfolio is not found with ID: {id}");

        var result = mapper.Map<PortfolioResultDto>(existPortfolio);
        return result;
    }

    public async Task<IEnumerable<PortfolioResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var Portfolios = await repository.SelectAll().ToPaginate(@params).ToListAsync();
        var result = mapper.Map<IEnumerable<PortfolioResultDto>>(Portfolios);
        return result;
    }
}
