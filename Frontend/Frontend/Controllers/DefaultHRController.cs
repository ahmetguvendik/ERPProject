using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

[Authorize(Roles = "HR")]
public class DefaultHRController : Controller   
{
    public IActionResult Index()
    {
         return View();
    }
}