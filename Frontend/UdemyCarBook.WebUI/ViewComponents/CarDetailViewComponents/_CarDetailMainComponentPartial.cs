using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CarDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailMainComponentPartial : ViewComponent
{
	private readonly IHttpClientFactory _httpClientFactory;

	public _CarDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	public async Task<IViewComponentResult> InvokeAsync(int id)
	{
		ViewBag.Id = id;
		var client = _httpClientFactory.CreateClient();
		var respond = await client.GetAsync($"https://localhost:44323/api/Car/GetCarWithBrandById/{id}");
		if (respond.IsSuccessStatusCode)
		{
			var jsonData = await respond.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<ResultCarDTO>(jsonData);
			return View(values);
		}
		return View();
	}
}
