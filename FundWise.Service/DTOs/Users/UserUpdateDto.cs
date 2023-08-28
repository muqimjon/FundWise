using System.ComponentModel;

namespace FundWise.Service.DTOs;

public class UserUpdateDto
{
    [DisplayName("Id")]
    public long Id { get; set; }
    [DisplayName("Last name")]
    public string LastName { get; set; } = string.Empty;
    [DisplayName("First name")]
    public string FirstName { get; set; } = string.Empty;
    [DisplayName("Date of birth")]
    public DateTime DateOfBirth { get; set; }
    [DisplayName("Email")]
    public string Email { get; set; } = string.Empty;
    [DisplayName("Phone")]
    public string Phone { get; set; } = string.Empty;
    [DisplayName("Password")]
    public string Password { get; set; } = string.Empty;
}
