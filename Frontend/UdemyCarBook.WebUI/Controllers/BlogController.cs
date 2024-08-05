using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CarPricingDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class BlogController : Controller
{
	private readonly IHttpClientFactory _httpClientFactory;

	public BlogController(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
	}

	public async Task<IActionResult> Index()
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync("https://localhost:44323/api/Blogs/GetAllBlogsWithAuthorList");
		if (responseMessage.IsSuccessStatusCode)
		{
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDTO>>(jsonData);
			return View(values);
		}
		return View();
	}

	public async Task<IActionResult> BlogDetail(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var responseMessage = await client.GetAsync($"https://localhost:44323/api/Blogs/GetBlogByAuthorId?id={id}");
		if (responseMessage.IsSuccessStatusCode)
		{
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultAllBlogsWithAuthorDTO>(jsonData);
			ViewBag.Id = id;
            return View(values);
        }
		return View();
	}
}
