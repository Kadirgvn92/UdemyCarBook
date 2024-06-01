using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers;
public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClient;

    public ContactController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }

    public IActionResult Index()
    {

        return View();
    }
}
