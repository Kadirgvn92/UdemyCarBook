using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.CarPricingDTOs;
using UdemyCarBook.DTO.LocationDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("https://localhost:44323/api/Car/GetCarWithBrand");
        if (responseMessage2.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage2.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarDTO>>(jsonData);

            List<SelectListItem> list2 = (from x in values
                                         select new SelectListItem
                                         {
                                             Text = x.BrandName,
                                             Value = x.CarID.ToString(),
                                         }).ToList();
            ViewBag.Cars = list2;
        }
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Locations");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDTO>>(jsonData);

            List<SelectListItem> list = (from x in values
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.LocationID.ToString(),
                                         }).ToList();
            ViewBag.Location = list;
            return View();
        }
        return View();
    }
}
