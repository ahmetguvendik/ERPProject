using Microsoft.AspNetCore.Mvc;

namespace Frontend.ViewComponents.HRViewComponents;

public class _HRHeadComponentPartial  : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}