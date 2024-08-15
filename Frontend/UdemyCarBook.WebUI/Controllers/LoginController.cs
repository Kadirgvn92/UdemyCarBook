using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.LoginDTOs;
using UdemyCarBook.DTO.RegisterDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginDTO dTO)
    {
        //var client = _httpClientFactory.CreateClient();
        //var jsonData = JsonConvert.SerializeObject(dTO);
        //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //var responseMessage = await client.PostAsync("https://localhost:44323/api/Register/", stringContent);
        //if (responseMessage.IsSuccessStatusCode)
        //{
        //    return RedirectToAction("Index", "Login");
        //}
        return View();
    }
}
