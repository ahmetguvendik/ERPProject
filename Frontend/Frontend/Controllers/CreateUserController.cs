using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class CreateUserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}