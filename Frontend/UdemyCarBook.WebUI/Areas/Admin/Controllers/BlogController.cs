using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.AuthorDTOs;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.BrandDTOs;
using UdemyCarBook.DTO.CarDTOs;
using UdemyCarBook.DTO.CategoryDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class BlogController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Blogs/GetAllBlogsWithAuthorList");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Content(jsonData, "application/json");
        }
        return View();
    }
    public async Task<List<SelectListItem>> GetAuthors()
    {
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:44323/api/Authors");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        var values1 = JsonConvert.DeserializeObject<List<ResultAuthorDTO>>(jsonData1);
        List<SelectListItem> authors = (from x in values1
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.AuthorID.ToString(),
                                            }).ToList();

        return authors;
    }
    public async Task<List<SelectListItem>> GetCategories()
    {
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("https://localhost:44323/api/Categories");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData1);
        List<SelectListItem> categories = (from x in values1
                                        select new SelectListItem
                                        {
                                            Text = x.name,
                                            Value = x.categoryID.ToString(),
                                        }).ToList();

        return categories;
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Authors = await GetAuthors();
        ViewBag.Categories = await GetCategories();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogDTO dTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("https://localhost:44323/api/Blogs/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:44323/api/Blogs?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        ViewBag.Authors = await GetAuthors();
        ViewBag.Categories = await GetCategories();

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/Blogs/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateBlogDTO>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlogDTO DTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(DTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:44323/api/Blogs/", stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
