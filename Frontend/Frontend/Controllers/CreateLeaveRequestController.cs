using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class CreateLeaveRequestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}