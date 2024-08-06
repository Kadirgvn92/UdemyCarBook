using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CarDTOs;

namespace UdemyCarBook.WebUI.Controllers;
public class AdminCarController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AdminCarController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public string GenerateName()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        Random random = new Random();
        char[] stringChars = new char[6];

        for (int i = 0; i < 6; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        return new string(stringChars);
    }
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Car/GetCarWithBrand");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCarDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> Create(CreateCarDTO dTO)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(dTO.Image.FileName);
        var imagename = GenerateName() + extension;
        var savelocation = Path.Combine(resource, "wwwroot/productImages", imagename);

        using (var stream = new FileStream(savelocation, FileMode.Create))
        {
            await dTO.Image.CopyToAsync(stream);
        }
        dTO.CoverImageUrl = imagename;


        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/Car", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
