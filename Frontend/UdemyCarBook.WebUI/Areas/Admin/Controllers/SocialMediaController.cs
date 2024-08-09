using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.SocialMediaDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class SocialMediaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SocialMediaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetSocialMedias()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/SocialMedias");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Content(jsonData, "application/json");
        }
        return Json(new List<ResultSocialMediaDTO>());
    }


    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:44323/api/SocialMedias?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateSocialMediaDTO dTO)
    {

        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/SocialMedias/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet]
    public async Task<JsonResult> GetSocialMedia(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/SocialMedias/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateSocialMediaDTO>(jsonData);
            return Json(values);
        }
        return Json(null);
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateSocialMediaDTO DTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(DTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:44323/api/SocialMedias/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");

        }
        return View();
    }
}
