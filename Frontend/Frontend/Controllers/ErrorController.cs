using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class ErrorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}