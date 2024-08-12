using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CommentDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CommentViewComponents;

public class _CommentListByBlogComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        ViewBag.Id = id;
        var client = _httpClientFactory.CreateClient();
        var respond = await client.GetAsync($"https://localhost:44323/api/Comment/CommentListByBlog?id={id}");
        if (respond.IsSuccessStatusCode)
        {
            var jsonData = await respond.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
