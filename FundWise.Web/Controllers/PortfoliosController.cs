using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class PortfoliosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
