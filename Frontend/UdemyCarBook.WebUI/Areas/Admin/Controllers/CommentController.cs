using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.DTO.AboutDTOs;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.CommentDTOs;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class CommentController : Controller
{

    private readonly IHttpClientFactory _httpClientFactory;

    public CommentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int id)
    {
        TempData["id"] = id;
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync($"https://localhost:44323/api/Blogs/{id}");
       
        if (responseMessage1.IsSuccessStatusCode)
        {
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<UpdateBlogDTO>(jsonData1);
            ViewBag.Blog = values1.Title;
        }

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/Comment/CommentListByBlog?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.DeleteAsync($"https://localhost:44323/api/About?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UpdateApproval(int commentId, bool isApproved)
    {
        var client = _httpClientFactory.CreateClient();
        var dto = new UpdateApprovalDTO
        {
            CommentId = commentId,
            IsApproved = isApproved
        };

        var jsonData = JsonConvert.SerializeObject(dto);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PutAsync("https://localhost:44323/api/Comment/UpdateApproval", stringContent);

        if (responseMessage.IsSuccessStatusCode)
        {
            ViewBag.Message = "Yorum durumu başarıyla güncellendi.";
        }
        else
        {
            ViewBag.Message = "Yorum durumu güncellenirken bir hata oluştu.";
        }

        return RedirectToAction("Index","Comment", new {id = TempData["id"] }); 
    }

}
