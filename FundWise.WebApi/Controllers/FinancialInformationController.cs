using FundWise.Domain.Configurations;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class FinancialInformationController : BaseControl
{
    private readonly IFinancialDataService financialDataService;
    public FinancialInformationController(IFinancialDataService financialDataService)
    {
        this.financialDataService = financialDataService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(FinancialDataCreationDto dto)
        => Ok(new Response
        {
            Data = await financialDataService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(FinancialDataUpdateDto dto)
        => Ok(new Response
        {
            Data = await financialDataService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            Data = await financialDataService.RemoveByIdAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            Data = await financialDataService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Data = await financialDataService.RetrieveAllAsync(@params)
        });
}