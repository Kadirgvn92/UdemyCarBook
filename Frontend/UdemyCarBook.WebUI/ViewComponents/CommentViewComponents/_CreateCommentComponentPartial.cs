using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using UdemyCarBook.DTO.CommentDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CommentViewComponents;

public class _CreateCommentComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CreateCommentComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(CreateCommentDTo DTO)
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(DTO);
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responsMessage = await client.PostAsync("https://localhost:44323/api/Comment", stringContent);
        if (responsMessage.IsSuccessStatusCode)
        {
            ViewBag.Messaege = "Yorumunuz admin tarafından kontrol edilerek işlem yapılacaktır. Teşekkür ederiz";
        }
        return View();
    }
}
