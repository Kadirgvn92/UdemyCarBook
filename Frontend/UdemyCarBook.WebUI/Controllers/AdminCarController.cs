using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.BrandDTOs;
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
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:44323/api/Brand");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        var values1 =  JsonConvert.DeserializeObject<List<ResultBrandDTO>>(jsonData1);
        List<SelectListItem> brandvalues = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.BrandID.ToString(),
                                            }).ToList();
        ViewBag.BrandValues = brandvalues;  

        //var resource = Directory.GetCurrentDirectory();
        //var extension = Path.GetExtension(dTO.CoverImage.FileName);
        //var imagename = GenerateName() + extension;
        //var savelocation = Path.Combine(resource, "wwwroot/productImages", imagename);

        //using (var stream = new FileStream(savelocation, FileMode.Create))
        //{
        //    await dTO.CoverImage.CopyToAsync(stream);
        //}
        //dTO.CoverImageUrl = imagename;


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
