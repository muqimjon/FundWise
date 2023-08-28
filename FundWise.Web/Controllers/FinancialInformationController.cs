using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class FinancialInformationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
