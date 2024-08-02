﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.FooterAddressDTOs;
using UdemyCarBook.DTO.TestimonialDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.FooterAddressComponents;

public class _FooterAddressComponentPartial : ViewComponent
{ 
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/FooterAddresses");
        if(responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}

