using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.LocationDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class DefaultController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DefaultController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
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
    public IActionResult Index(int locationID, string pickUpDate, string dropofDate, string pickUpTime, string dropofTime)
    {
        TempData["LocationID"] = locationID;
        TempData["pickUpDate"] = pickUpDate;
        TempData["dropofDate"] = dropofDate;
        TempData["pickUpTime"] = pickUpTime;
        TempData["dropofTime"] = dropofTime;

        return RedirectToAction("Index", "RentACar");  
    }
}
