using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

[Authorize(Roles = "Staff")]
public class DefaultStaffController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}