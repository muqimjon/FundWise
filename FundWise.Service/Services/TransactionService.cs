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

public class TransactionService : ITransactionService
{
    private readonly IMapper mapper;
    private readonly IRepository<Asset> assetRepo;
    private readonly IRepository<Transaction> repository;

    public TransactionService(IRepository<Transaction> repository, IMapper mapper, IRepository<Asset> assetRepo)
    {
        this.mapper = mapper;
        this.assetRepo = assetRepo;
        this.repository = repository;
    }

    public async Task<TransactionResultDto> AddAsync(TransactionCreationDto dto)
    {
        var existAsset = await assetRepo.SelectAsync(u => u.Id.Equals(dto.AssetId))
            ?? throw new NotFoundException($"This Asset is not found with ID: {dto.AssetId}");

        var mappedTransaction = mapper.Map<Transaction>(dto);
        await repository.CreateAsync(mappedTransaction);
        await repository.SaveAsync();

        var result = mapper.Map<TransactionResultDto>(mappedTransaction);
        return result;
    }

    public async Task<TransactionResultDto> ModifyAsync(TransactionUpdateDto dto)
    {
        Transaction existTransaction = await repository.SelectAsync(u => u.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This Transaction is not found with ID: {dto.Id}");

        var existAsset = await assetRepo.SelectAsync(u => u.Id.Equals(dto.AssetId))
            ?? throw new NotFoundException($"This Asset is not found with ID: {dto.AssetId}");

        mapper.Map(dto, existTransaction);
        repository.Update(existTransaction);
        await repository.SaveAsync();

        var result = mapper.Map<TransactionResultDto>(existTransaction);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        Transaction existTransaction = await repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This Transaction is not found with ID: {id}");

        await repository.DeleteAsync(e => e.Id == id);
        await repository.SaveAsync();

        var result = mapper.Map<TransactionResultDto>(existTransaction);
        return true;
    }

    public async Task<TransactionResultDto> RetrieveByIdAsync(long id)
    {
        Transaction existTransaction = await repository.SelectAsync(u => u.Id.Equals(id))
            ?? throw new NotFoundException($"This Transaction is not found with ID: {id}");

        var result = mapper.Map<TransactionResultDto>(existTransaction);
        return result;
    }

    public async Task<IEnumerable<TransactionResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var Transactions = await repository.SelectAll().ToPaginate(@params).ToListAsync();
        var result = mapper.Map<IEnumerable<TransactionResultDto>>(Transactions);
        return result;
    }
}
