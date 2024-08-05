using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.TagCloudDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailTagComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailTagComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var respond = await client.GetAsync($"https://localhost:44323/api/TagClouds/GetTagCloudByBlogId?id={id}");
        if (respond.IsSuccessStatusCode)
        {
            var jsonData = await respond.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTagCloudDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
