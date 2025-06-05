using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.HRViewComponents;

public class _HRSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}