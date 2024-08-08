using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.ContactDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ContactsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ContactsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Contacts");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return Content(jsonData, "application/json");
        }
        return Json(new List<ResultContactDTO>());
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:44323/api/Contacts?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }
}
