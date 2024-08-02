using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.BannerDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultCoverUILayoutComponentPartial :ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var clients = _httpClientFactory.CreateClient();
        var responseMessage = await clients.GetAsync("https://localhost:44323/api/Banner");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
