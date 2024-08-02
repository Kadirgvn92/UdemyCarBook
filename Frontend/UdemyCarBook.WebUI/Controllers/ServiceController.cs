using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.ServiceDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class ServiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Services");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
