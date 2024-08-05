using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AdminLayout;

public class _AdminHeaderPartial : ViewComponent
{

    public async Task<IViewComponentResult> InvokeAsync()
    {

        return View();
    }
}
