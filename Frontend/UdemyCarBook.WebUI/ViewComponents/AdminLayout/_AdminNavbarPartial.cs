using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AdminLayout;

public class _AdminNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
