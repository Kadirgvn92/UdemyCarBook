﻿using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents;

public class _BlogDetailTagComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
