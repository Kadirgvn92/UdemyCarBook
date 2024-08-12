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

    public IViewComponentResult Invoke()
    {
       return View();
    }
}
