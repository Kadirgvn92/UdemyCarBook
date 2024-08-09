using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.ServiceDTOs;
using UdemyCarBook.DTO.ServiceDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ServiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Services");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Content(jsonData, "application/json");
        }
        return Json(new List<ResultServiceDTO>());
    }


    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:44323/api/Services?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceDTO dTO)
    {

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/Services/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet]
    public async Task<JsonResult> GetService(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/Services/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateServiceDTO>(jsonData);
            return Json(values);
        }
        return Json(null);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateServiceDTO DTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(DTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:44323/api/Services/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");

        }
        return View();
    }
}
