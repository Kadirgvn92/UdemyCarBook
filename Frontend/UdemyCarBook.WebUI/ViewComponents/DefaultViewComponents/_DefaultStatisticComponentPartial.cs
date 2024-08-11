using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using UdemyCarBook.DTO.StatisticDTOs;
using UdemyCarBook.WebUI.Areas.Admin.Models;

namespace UdemyCarBook.WebUI.ViewComponents.DefaultViewComponents;

public class _DefaultStatisticComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<ResultStatisticCountDTO> GetCount(string url)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{url}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultStatisticCountDTO>(jsonData);
            return values;
        }
        return null;
    }
    public async Task<ResultStatisticPriceDTO> GetPrice(string url)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{url}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultStatisticPriceDTO>(jsonData);
            return values;
        }
        return null;
    }
    public async Task<ResultStatisticCarDTO> GetCar(string url)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{url}");

        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultStatisticCarDTO>(jsonData);
            return values;
        }
        return null;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var carCount = await GetCount("https://localhost:44323/api/Statistic/GetCarCount");
        var locationCount = await GetCount("https://localhost:44323/api/Statistic/GetLocationCount");
        var authorCount = await GetCount("https://localhost:44323/api/Statistic/GetAuhtorCount");
        var blogCount = await GetCount("https://localhost:44323/api/Statistic/GetBlogCount");
        var model = new StatisticViewModel
        {
            CarCount = carCount,
            LocationCount = locationCount,
            AuthorCount = authorCount,
            BlogCount = blogCount
        };
        return View(model);
    }
}
