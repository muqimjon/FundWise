using AutoMapper;
using FundWise.Domain.Enums;
using FundWise.Service.DTOs;
using FundWise.Domain.Entities;
using FundWise.Service.Exceptions;
using FundWise.Service.Extensions;
using FundWise.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using FundWise.Domain.Configurations;
using FundWise.DataAccess.IRepositories;

namespace FundWise.Service.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;
    private readonly IMapper mapper;

    public UserService(IRepository<User> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        User existUser = await repository.SelectAsync(u => u.Phone.Equals(dto.Phone));
        if (existUser is not null)
            throw new AlreadyExistException($"This user is already exist with phone {dto.Phone}");

        existUser = await repository.SelectAsync(u => u.Email.Equals(dto.Email));
        if (existUser is not null)
            throw new AlreadyExistException($"This user is already exist with email {dto.Email}");

        var mappedUser = mapper.Map<User>(dto);

        mappedUser.Role = repository.SelectAll().Any()? UserRole.User : UserRole.Admin;

        mappedUser.Password = dto.Password.Encrypt();
        await repository.CreateAsync(mappedUser);
        await repository.SaveAsync();

        var result = mapper.Map<UserResultDto>(mappedUser);
        return result;
    }

    public async Task<UserResultDto> RetrieveByEmailAsync(string email)
    {
        User existUser = await repository.SelectAsync(u => u.Email.Equals(email), includes: new[] {"Portfolios" })
        ?? throw new NotFoundException($"This user is not found with ID: {email}");

        var result = mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<UserResultDto> RetrieveByPhoneAsync(string phone)
    {
        User existUser = await repository.SelectAsync(u => u.Phone.Equals(phone), includes: new[] { "Portfolios" })
        ?? throw new NotFoundException($"This user is not found with ID: {phone}");

        var result = mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        User existUser = await repository.SelectAsync(u => u.Id.Equals(dto.Id))
        ?? throw new NotFoundException($"This user is not found with ID: {dto.Id}");

        mapper.Map(dto, existUser);
        existUser.Password = existUser.Password.Encrypt();
        repository.Update(existUser);
        await repository.SaveAsync();

        var result = mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        User existUser = await repository.SelectAsync(u => u.Id.Equals(id))
        ?? throw new NotFoundException($"This user is not found with ID: {id}");

        await repository.DeleteAsync(e => e.Id == id);
        await repository.SaveAsync();

        var result = mapper.Map<UserResultDto>(existUser);
        return true;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var users = await repository.SelectAll().ToPaginate(@params).ToListAsync();
        var result = mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = (await repository.SelectAll().ToListAsync()).Where(i => !i.IsDeleted);
        var result = mapper.Map<IEnumerable<UserResultDto>>(users);
        return result;
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        User existUser = await repository.SelectAsync(u => u.Id.Equals(id), includes: new[] { "Portfolios" })
        ?? throw new NotFoundException($"This user is not found with ID: {id}");

        var result = mapper.Map<UserResultDto>(existUser);
        return result;
    }

    public async Task<UserResultDto> ChangeUserRole(string role, long id)
    {
        User existUser = await repository.SelectAsync(u => u.Id.Equals(id), includes: new[] { "Portfolios" })
        ?? throw new NotFoundException($"This user is not found with ID: {id}");

        if (Enum.TryParse($"UserRole.{role}", out UserRole userRole))
            existUser.Role = userRole;
        else
            throw new NotFoundException($"This Role is not found: {role}");

        repository.Update(existUser);
        await repository.SaveAsync();

        return mapper.Map<UserResultDto>(existUser);
    }
}
