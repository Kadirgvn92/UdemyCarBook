using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.ViewComponents;

public class _AdminDashboardCardsComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
