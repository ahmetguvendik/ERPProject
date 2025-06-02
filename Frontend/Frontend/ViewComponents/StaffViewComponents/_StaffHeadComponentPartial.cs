using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.StaffViewComponents;

public class _StaffHeadComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}