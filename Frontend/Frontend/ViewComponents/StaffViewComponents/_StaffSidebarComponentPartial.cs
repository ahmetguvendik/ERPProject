using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.StaffViewComponents;

public class _StaffSidebarComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}