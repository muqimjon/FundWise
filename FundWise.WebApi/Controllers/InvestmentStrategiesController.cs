using FundWise.Domain.Configurations;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class InvestmentStrategiesController : BaseControl
{
    private readonly IInvestmentStrategyService investmentStrategyService;
    public InvestmentStrategiesController(IInvestmentStrategyService investmentStrategyService)
    {
        this.investmentStrategyService = investmentStrategyService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(InvestmentStrategyCreationDto dto)
        => Ok(new Response
        {
            Data = await investmentStrategyService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(InvestmentStrategyUpdateDto dto)
        => Ok(new Response
        {
            Data = await investmentStrategyService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            Data = await investmentStrategyService.RemoveByIdAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            Data = await investmentStrategyService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Data = await investmentStrategyService.RetrieveAllAsync(@params)
        });
}

