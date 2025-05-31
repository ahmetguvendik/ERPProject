using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class StaffController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}