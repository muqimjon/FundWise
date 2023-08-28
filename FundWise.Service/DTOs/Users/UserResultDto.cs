using FundWise.Domain.Entities;
using FundWise.Domain.Enums;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace FundWise.Service.DTOs;

public class UserResultDto
{
    [DisplayName("Id")]
    public long Id { get; set; }
    [DisplayName("LastName")]
    public string LastName { get; set; } = string.Empty;
    [DisplayName("FirstName")]
    public string FirstName { get; set; } = string.Empty;
    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;
    [DisplayName("Phone")]
    public string Phone { get; set; } = string.Empty;
    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;
    [DisplayName("Role")]
    public UserRole Role { get; set; } = UserRole.User;

    public List<Portfolio> Portfolios { get; set; } = default!;
}