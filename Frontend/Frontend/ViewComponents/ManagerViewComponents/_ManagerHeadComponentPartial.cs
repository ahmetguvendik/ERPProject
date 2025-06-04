using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.ManagerViewComponents;

public class _ManagerHeadComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}