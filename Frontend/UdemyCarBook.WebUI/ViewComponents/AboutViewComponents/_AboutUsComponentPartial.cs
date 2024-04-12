using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UdemyCarBook.WebUI.ViewComponents.AboutViewComponents;

public class _AboutUsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task< IViewComponentResult> InvokeAsync()
    {
        var clients = _httpClientFactory.CreateClient();
        var responseMessage = await clients.GetAsync("https://localhost:7259/api/About");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();   
            //var values = JsonConvert.DeserializeObject<List<>>(jsonData);
        }
        return View();
    }
}
