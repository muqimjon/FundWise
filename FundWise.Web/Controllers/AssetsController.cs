using FundWise.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class AssetsController : Controller
{
    private readonly IAssetService service;

    public AssetsController(IAssetService service)
    {
        this.service = service;
    }

    public async Task<IActionResult> Index()
    {
        var assets = await service.RetrieveAllAsync();
        return View(assets);
    }
}
