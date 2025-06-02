using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.StaffViewComponents;

public class _StaffWrapperComponentPartial :  ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}