using FundWise.Service.Interfaces;
using FundWise.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class FinancialInformationController : Controller
{
    private readonly IFinancialDataService service;

    public FinancialInformationController(IFinancialDataService service)
    {
        this.service = service;
    }

    public async Task<IActionResult> Index()
    {
        var dtos = await service.RetrieveAllAsync();
        return View(dtos);
    }
}
