using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BannerDTOs;
using UdemyCarBook.DTO.CarDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultLast5CarsWithBrandsComponentPartial :ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var clients = _httpClientFactory.CreateClient();
        var responseMessage = await clients.GetAsync("https://localhost:44323/api/Car/GetLast5CarWithBrand");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandsDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
