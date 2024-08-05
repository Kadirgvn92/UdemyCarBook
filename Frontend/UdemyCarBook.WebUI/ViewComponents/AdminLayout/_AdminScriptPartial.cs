using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AdminLayout;

public class _AdminScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
