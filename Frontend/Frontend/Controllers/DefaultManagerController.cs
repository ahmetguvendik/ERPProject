using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class DefaultManagerController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}