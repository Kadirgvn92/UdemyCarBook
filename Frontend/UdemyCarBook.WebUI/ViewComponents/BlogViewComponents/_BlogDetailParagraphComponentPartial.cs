using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.StatisticDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailParagraphComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _BlogDetailParagraphComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.Id = id;
        var client = _httpClientFactory.CreateClient();
        var respond = await client.GetAsync($"https://localhost:44323/api/Comment/CommentCountByBlog?id={id}");
        if (respond.IsSuccessStatusCode)
        {
            var jsonData = await respond.Content.ReadAsStringAsync();
            ViewBag.Count = jsonData;
            
        }
        return View();
    }
}
