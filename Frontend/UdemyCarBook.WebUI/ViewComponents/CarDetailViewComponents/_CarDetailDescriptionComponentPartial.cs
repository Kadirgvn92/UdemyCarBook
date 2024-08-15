using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.CarDescriptionDTOs;
using UdemyCarBook.DTO.CarFeatureDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailDescriptionComponentPartial : ViewComponent
{
	private readonly IHttpClientFactory _httpClientFactory;

	public _CarDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}
	public async Task<IViewComponentResult> InvokeAsync(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"https://localhost:44323/api/CarDescription?id={id}");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<ResultCarDescriptionDTO>(jsonData);
			return View(values);
		}
		return View();
	}
}
