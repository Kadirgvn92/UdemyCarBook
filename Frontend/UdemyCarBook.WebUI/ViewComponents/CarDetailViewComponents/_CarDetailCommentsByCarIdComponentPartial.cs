﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.CarDescriptionDTOs;
using UdemyCarBook.DTO.ReviewDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.CarDetailViewComponents;

public class _CarDetailCommentsByCarIdComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"https://localhost:44323/api/Review?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultReviewDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
