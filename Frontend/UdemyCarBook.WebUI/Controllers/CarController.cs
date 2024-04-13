using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.ServiceDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class CarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:7259/api/Car/GetCarWithBrand");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
