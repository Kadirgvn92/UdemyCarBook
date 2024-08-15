using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.CarFeatureDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailFeatureDetailComponentPartial : ViewComponent
{
	private readonly IHttpClientFactory _httpClientFactory;

	public _CarDetailFeatureDetailComponentPartial(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	public async Task<IViewComponentResult> InvokeAsync(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"https://localhost:44323/api/CarFeatures?id={id}");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDTO>>(jsonData);
			return View(values);
		}
		return View();
	}
}
