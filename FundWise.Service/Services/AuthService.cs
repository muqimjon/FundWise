using System.Text;
using System.Security.Claims;
using FundWise.Domain.Entities;
using FundWise.Service.Exceptions;
using FundWise.Service.Extensions;
using FundWise.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using FundWise.DataAccess.IRepositories;

namespace FundWise.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> repository;
    private readonly IConfiguration configuration;

    public AuthService(IRepository<User> repository, IConfiguration configuration)
    {
        this.repository = repository;
        this.configuration = configuration;
    }

    public async Task<string> GenerateTokenAsync(string phone, string password)
    {
        var user = await repository.SelectAsync(u => u.Phone.Equals(phone))
            ?? throw new NotFoundException($"This user is not found with Phone: {phone}");
        bool verifiedPassword = user.Password.Verify(password);

        if (!verifiedPassword)
            throw new CustomException(401, "Phone or password is invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
          {
             new Claim("Phone", user.Phone),
             new Claim("Id", user.Id.ToString()),
             new Claim(ClaimTypes.Role, user.Role.ToString())
          }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string result = tokenHandler.WriteToken(token);
        return result;
    }
}
