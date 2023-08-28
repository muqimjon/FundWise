using FundWise.Domain.Enums;

namespace FundWise.Domain.Entities;

public class User : Auditable
{
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }

    public List<Portfolio> Portfolios { get; set; } = default!;
}