using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers;
public class CarPricingController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
