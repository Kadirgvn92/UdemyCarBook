using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers;
public class RentACarController : Controller
{
    public IActionResult Index()
    {
        var data = TempData["value"];
        ViewBag.v = data;
        return View();
    }
}
