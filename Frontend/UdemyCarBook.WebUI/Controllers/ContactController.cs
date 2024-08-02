using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.ContactDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class ContactController : Controller
{
    private readonly IHttpClientFactory _httpClient;

    public ContactController(IHttpClientFactory httpClient)
    {
        _httpClient = httpClient;
    }
    [HttpGet]
    public IActionResult Index()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateContactDto contactDto)
    {
        var client = _httpClient.CreateClient();
        contactDto.SendDate = DateTime.Now;
        var jsonData = JsonConvert.SerializeObject(contactDto);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8,"application/json");
        var responsMessage = await client.PostAsync("https://localhost:44323/api/Contacts",stringContent);
        if (responsMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index","Default");
        }
        return View();
    }
}
