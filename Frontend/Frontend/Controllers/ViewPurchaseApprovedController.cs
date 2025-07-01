using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class ViewPurchaseApprovedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}