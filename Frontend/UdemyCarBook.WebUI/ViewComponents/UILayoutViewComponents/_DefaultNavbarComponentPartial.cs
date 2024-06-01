using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents;

public class _DefaultNavbarComponentPartial : ViewComponent
{
  public IViewComponentResult Invoke()
    {
        return View();
    }
}
