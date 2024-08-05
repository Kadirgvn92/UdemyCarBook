using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AdminLayout;

public class _AdminSidebarPartial : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {

        return View();

    }
}
