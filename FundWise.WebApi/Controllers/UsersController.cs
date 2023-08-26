using FundWise.Domain.Configurations;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class UsersController : BaseControl
{
    private readonly IUserService userService;
    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(UserCreationDto dto)
        => Ok(new Response { Data = await userService.AddAsync(dto) });

    
    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(UserUpdateDto dto)
        => Ok(new Response { Data = await userService.ModifyAsync(dto) });

    
    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response { Data = await userService.RemoveByIdAsync(id) });

    
    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response { Data = await userService.RetrieveByIdAsync(id) });


    [Authorize(Roles = "Admin"), HttpPatch("edit-user-role")]
    public async Task<IActionResult> ChangeUserRoleAsync(string role, long id)
        => Ok(new Response { Data = await userService.ChangeUserRole(role, id) });


    [HttpGet("get/{phone}")]
    public async Task<IActionResult> GetByPhoneAsync(string phone)
        => Ok(new Response { Data = await userService.RetrieveByPhoneAsync(phone) });


    [HttpGet("get/{email}")]
    public async Task<IActionResult> GetByEmailAsync(string email)
        => Ok(new Response { Data = await userService.RetrieveByEmailAsync(email) });


    [Authorize(Roles = "Admin"), HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response { Data = await userService.RetrieveAllAsync(@params) });
}
