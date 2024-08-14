using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.CarFeatureDTOs;
using UdemyCarBook.DTO.FeatureDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class FeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Feature");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Detail(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/CarFeatures?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarFeatureDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> CreateFeatureByCarID()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/Feature");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Detail(List<ResultCarFeatureDTO> DTO)
    {
        foreach(var item in DTO)
        {
            if (item.Available)
            {
                var client = _httpClientFactory.CreateClient();
                await client.GetAsync($"https://localhost:44323/api/CarFeatures/CarFeatureChangeAvailableToTrue?id={item.CarFeatureID}");
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                await client.GetAsync($"https://localhost:44323/api/CarFeatures/CarFeatureChangeAvailableToFalse?id={item.CarFeatureID}");
            }
        }
        return RedirectToAction("Index","Car");
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDTO dTO)
    {

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/Feature/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:44323/api/Feature?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/Feature/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateFeatureDTO>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateFeatureDTO updateCarDTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(updateCarDTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:44323/api/Feature/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
