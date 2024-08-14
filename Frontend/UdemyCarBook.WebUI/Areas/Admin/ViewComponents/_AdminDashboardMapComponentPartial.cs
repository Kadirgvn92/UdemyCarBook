using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardMapComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
