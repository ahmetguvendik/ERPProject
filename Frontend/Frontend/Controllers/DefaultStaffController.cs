using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class DefaultStaffController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}