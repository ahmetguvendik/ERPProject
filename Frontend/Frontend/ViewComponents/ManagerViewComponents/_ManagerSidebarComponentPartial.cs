using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.ManagerViewComponents;

public class _ManagerSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}