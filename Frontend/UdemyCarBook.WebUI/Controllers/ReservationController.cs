using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers;
public class ReservationController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
