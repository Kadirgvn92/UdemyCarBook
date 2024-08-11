using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.BlogDTOs;
using UdemyCarBook.DTO.FooterAddressDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.UILayoutViewComponents;

public class _FooterComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _FooterComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var respond = await client.GetAsync($"https://localhost:44323/api/FooterAddresses");
        if (respond.IsSuccessStatusCode)
        {
            var jsonData = await respond.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
