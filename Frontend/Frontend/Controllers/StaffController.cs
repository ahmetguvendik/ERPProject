using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class StaffController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
