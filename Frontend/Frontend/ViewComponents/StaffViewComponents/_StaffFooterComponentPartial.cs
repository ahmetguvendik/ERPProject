using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.StaffViewComponents;

public class _StaffFooterComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}