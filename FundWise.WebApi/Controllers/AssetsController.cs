using FundWise.Domain.Configurations;
using FundWise.Service.DTOs;
using FundWise.Service.Interfaces;
using FundWise.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.WebApi.Controllers;

public class AssetsController : BaseControl
{
    private readonly IAssetService assetService;
    public AssetsController(IAssetService assetService)
    {
        this.assetService = assetService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> PostAsync(AssetCreationDto dto)
        => Ok(new Response
        {
            Data = await assetService.AddAsync(dto)
        });


    [HttpPut("update")]
    public async Task<IActionResult> PutAsync(AssetUpdateDto dto)
        => Ok(new Response
        {
            Data = await assetService.ModifyAsync(dto)
        });

    [HttpDelete("delete/{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
        => Ok(new Response
        {
            Data = await assetService.RemoveByIdAsync(id)
        });

    [HttpGet("get/{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
        => Ok(new Response
        {
            Data = await assetService.RetrieveByIdAsync(id)
        });

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(new Response
        {
            Data = await assetService.RetrieveAllAsync(@params)
        });
}
