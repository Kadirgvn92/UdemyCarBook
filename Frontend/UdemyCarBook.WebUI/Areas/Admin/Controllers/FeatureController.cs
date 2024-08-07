using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;
public class FeatureController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
