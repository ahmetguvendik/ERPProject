using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.StaffViewComponents;

public class _StaffScriptComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}