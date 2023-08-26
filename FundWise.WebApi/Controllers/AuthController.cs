using FundWise.Service.Interfaces;
using FundWise.Service.Services;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class AuthController : BaseControl
{
    private readonly IAuthService authService;
    public AuthController(IAuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> GenerateToken(string phone, string password)
        => Ok(new Response { Data = await authService.GenerateTokenAsync(phone, password) });
}
