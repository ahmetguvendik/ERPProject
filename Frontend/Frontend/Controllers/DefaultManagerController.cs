using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

[Authorize(Roles = "Manager")]
public class DefaultManagerController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}