using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.CarPricingDTOs;
using UdemyCarBook.DTO.LocationDTOs;
using UdemyCarBook.DTO.ReservationDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {
        ViewBag.Id = id;    
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
    [HttpPost]
    public async Task<IActionResult> Index(CreateReservationDTO DTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(DTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/Reservation/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index","Default");
        }
        return View();
    }
}
