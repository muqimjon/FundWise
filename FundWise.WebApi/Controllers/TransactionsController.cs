using FundWise.Domain.Configurations;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class TransactionsController : BaseControl
{
    private readonly ITransactionService transactionService;
    public TransactionsController(ITransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(TransactionCreationDto dto)
        => Ok(new Response
        {
            Data = await transactionService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(TransactionUpdateDto dto)
        => Ok(new Response
        {
            Data = await transactionService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            Data = await transactionService.RemoveByIdAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            Data = await transactionService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Data = await transactionService.RetrieveAllAsync(@params)
        });
}
