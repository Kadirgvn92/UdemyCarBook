using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.ServiceDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.ServiceComponents;

public class _ServiceComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Services");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
