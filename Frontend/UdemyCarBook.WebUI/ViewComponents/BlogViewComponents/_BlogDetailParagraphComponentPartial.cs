using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailParagraphComponentPartial : ViewComponent
{
   public IViewComponentResult Invoke(int id)
    {
        ViewBag.Id = id;    
        return View();
    }
}
