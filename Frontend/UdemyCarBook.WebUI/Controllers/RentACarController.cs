using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.RentACarDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class RentACarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RentACarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int id)
    {
        var LocationID = TempData["LocationID"];
        

        id = int.Parse(LocationID.ToString());

        ViewBag.LocationID = LocationID;


        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/RentACar?locationID={id}&isAvailable=true");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<FilterRentACarDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
