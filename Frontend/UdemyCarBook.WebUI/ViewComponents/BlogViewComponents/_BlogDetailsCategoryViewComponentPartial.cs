using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CategoryDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailsCategoryViewComponentPartial :ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailsCategoryViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var respond = await client.GetAsync("https://localhost:44323/api/Categories");
        if (respond.IsSuccessStatusCode)
        {
            var jsonData = await respond.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
