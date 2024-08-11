using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.DTO.CarPricingDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class CarPricingController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public CarPricingController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
    {
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:44323/api/CarPricings/GetCarPricingWithTimePeriod");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithTime>>(jsonData);
			return View(values);
		}
		return View();
	}
}
