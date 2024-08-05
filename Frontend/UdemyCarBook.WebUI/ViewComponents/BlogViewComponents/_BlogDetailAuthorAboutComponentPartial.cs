using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailAuthorAboutComponentPartial :ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var respond = await client.GetAsync($"https://localhost:44323/api/Blogs/GetBlogByAuthorId?id={id}");
        if (respond.IsSuccessStatusCode)
        {
            var jsonData = await respond.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultAllBlogsWithAuthorDTO>(jsonData);
            return View(values);
        }
        return View();
    }
}
