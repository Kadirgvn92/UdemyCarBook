using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CarPricingDTOs;
using UdemyCarBook.DTO.CommentDTOs;

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
            TempData["BlogId"] = id;
            ViewBag.Message = TempData["Message"];
            return View(values);
        }
		return View();
	}
    [HttpPost]
    public async Task<IActionResult> AddComment(CreateCommentDTo DTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(DTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/Comment/CreateCommentWithMediatR", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            TempData["Message"] = "Yorumunuz admin tarafından kontrol edilerek işlem yapılacaktır. Teşekkür ederiz.";
        }
        else
        {
            TempData["Message"] = "Yorum gönderme işlemi başarısız oldu. Lütfen tekrar deneyin.";
        }

        // BlogDetail sayfasına yönlendirme yaparken TempData'daki BlogId'yi kullanıyoruz
        return RedirectToAction("BlogDetail", new { id = TempData["BlogId"] });
    }
}
