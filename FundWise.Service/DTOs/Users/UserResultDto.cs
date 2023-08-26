using FundWise.Domain.Entities;
using FundWise.Domain.Enums;

namespace FundWise.Service.DTOs;

public class UserResultDto
{
    public long Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;

    public List<Portfolio> Portfolios { get; set; } = default!;
}