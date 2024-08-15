using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.CarPricingDTOs;
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
        var responseMessage = await client.GetAsync("https://localhost:44323/api/CarPricings/GetCarPricingWithCar");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultGetCarPricingDto>>(jsonData);
            return View(values);
        }
        return View();
    }
	public async Task<IActionResult> Detail(int id)
	{
		ViewBag.Id = id;
		return View();
	}
}
