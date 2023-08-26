using FundWise.Service.DTOs;
using FundWise.Service.Interfaces.Commons;

namespace FundWise.Service.Interfaces;

public interface IUserService : IServiceInterface<UserCreationDto, UserUpdateDto, UserResultDto>
{
    Task<UserResultDto> RetrieveByPhoneAsync(string phone);
    Task<UserResultDto> RetrieveByEmailAsync(string email);
    Task<UserResultDto> ChangeUserRole(string role, long id);
}
