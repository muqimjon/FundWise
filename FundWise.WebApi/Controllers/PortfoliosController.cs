using FundWise.Domain.Configurations;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class PortfoliosController : BaseControl
{
    private readonly IPortfolioService portfolioService;
    public PortfoliosController(IPortfolioService portfolioService)
    {
        this.portfolioService = portfolioService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(PortfolioCreationDto dto)
        => Ok(new Response
        {
            Data = await portfolioService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(PortfolioUpdateDto dto)
        => Ok(new Response
        {
            Data = await portfolioService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            Data = await portfolioService.RemoveByIdAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            Data = await portfolioService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Data = await portfolioService.RetrieveAllAsync(@params)
        });
}