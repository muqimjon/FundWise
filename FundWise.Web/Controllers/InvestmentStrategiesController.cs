using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class InvestmentStrategiesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
