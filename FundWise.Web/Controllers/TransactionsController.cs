using Microsoft.AspNetCore.Mvc;

namespace FundWise.Web.Controllers;

public class TransactionsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
