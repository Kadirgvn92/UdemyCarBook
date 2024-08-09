using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.FeatureDTOs;
using UdemyCarBook.DTO.PricingDTOs;
using UdemyCarBook.DTO.StatisticDTOs;
using UdemyCarBook.WebUI.Areas.Admin.Models;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class StatisticController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StatisticController(IHttpClientFactory httpClientFactory)
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

    public async Task<IActionResult> Index()
    {
        var carCount = await GetCount("https://localhost:44323/api/Statistic/GetCarCount");
        var locationCount = await GetCount("https://localhost:44323/api/Statistic/GetLocationCount");
        var authorCount = await GetCount("https://localhost:44323/api/Statistic/GetAuhtorCount");
        var blogCount = await GetCount("https://localhost:44323/api/Statistic/GetBlogCount");
        var pricingCount = await GetCount("https://localhost:44323/api/Statistic/GetPricingCount");
        var featureCount = await GetCount("https://localhost:44323/api/Statistic/GetCarFeatureCount");
        var serviceCount = await GetCount("https://localhost:44323/api/Statistic/GetServiceCount");
        var testimonialCount = await GetCount("https://localhost:44323/api/Statistic/GetTestimonialCount");
        var expensivePrice = await GetPrice("https://localhost:44323/api/Statistic/GetMostExpensivePrice");
        var cheapPrice = await GetPrice("https://localhost:44323/api/Statistic/GetMostCheapPrice");
        var weeklyPrice = await GetPrice("https://localhost:44323/api/Statistic/GetWeeklyAvgRentPrice");
        var hourlyPrice = await GetPrice("https://localhost:44323/api/Statistic/GetHourlyAvgRentPrice");
        var dailyPrice = await GetPrice("https://localhost:44323/api/Statistic/GetDailyAvgRentPrice");
        var montlyPrice = await GetPrice("https://localhost:44323/api/Statistic/GetMontlyAvgRentPrice");
        var expensiveCar = await GetCar("https://localhost:44323/api/Statistic/GetMostExpensiveCar");
        var cheapCar = await GetCar("https://localhost:44323/api/Statistic/GetMostCheapCar");
        var model = new StatisticViewModel
        {
            CarCount = carCount,
            LocationCount = locationCount,
            AuthorCount = authorCount,
            BlogCount = blogCount,
            PricingCount = pricingCount,
            CarFeatureCount = featureCount,
            CheapCar = cheapCar,
            ExpensiveCar = expensiveCar,
            DailyAvgRentPrice = dailyPrice,
            WeeklyAvgRentPrice= weeklyPrice,
            HourlyAvgRentPrice = hourlyPrice,
            MontlyAvgRentPrice = montlyPrice,
            MostCheapPrice = cheapPrice,
            MostExpensivePrice = expensivePrice,
            TestimonialCount = testimonialCount,
            ServiceCount = serviceCount,
        };
        return View(model);
    }
}
