using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class HRController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}