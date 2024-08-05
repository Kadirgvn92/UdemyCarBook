using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AdminLayout;

public class _AdminFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
