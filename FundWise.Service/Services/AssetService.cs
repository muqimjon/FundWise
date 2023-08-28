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

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> repository;
    private readonly IMapper mapper;

    public AssetService(IRepository<Asset> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<AssetResultDto> AddAsync(AssetCreationDto dto)
    {
        var mappedAsset = mapper.Map<Asset>(dto);
        await repository.CreateAsync(mappedAsset);
        await repository.SaveAsync();

        var result = mapper.Map<AssetResultDto>(mappedAsset);
        return result;
    }

    public async Task<AssetResultDto> ModifyAsync(AssetUpdateDto dto)
    {
        Asset existAsset = await repository.SelectAsync(u => u.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This Asset is not found with ID: {dto.Id}");

        mapper.Map(dto, existAsset);
        repository.Update(existAsset);
        await repository.SaveAsync();

        var result = mapper.Map<AssetResultDto>(existAsset);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        Asset existAsset = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This Asset is not found with ID: {id}");

        await repository.DeleteAsync(e => e.Id == id);
        await repository.SaveAsync();

        var result = mapper.Map<AssetResultDto>(existAsset);
        return true;
    }

    public async Task<AssetResultDto> RetrieveByIdAsync(long id)
    {
        Asset existAsset = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This Asset is not found with ID: {id}");

        var result = mapper.Map<AssetResultDto>(existAsset);
        return result;
    }

    public async Task<IEnumerable<AssetResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var Assets = await repository.SelectAll().ToPaginate(@params).ToListAsync();
        var result = mapper.Map<IEnumerable<AssetResultDto>>(Assets);
        return result;
    }

    public async Task<IEnumerable<AssetResultDto>> RetrieveAllAsync()
    {
        var Assets = (await repository.SelectAll().ToListAsync()).Where(i => !i.IsDeleted);
        var result = mapper.Map<IEnumerable<AssetResultDto>>(Assets);
        return result;
    }
}
