using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.DTO.TestimonialDTOs;

namespace UdemyCarBook.WebUI.ViewComponents.TestimonialViewComponents;

public class _TestimonialComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync("https://localhost:44323/api/Testimonials");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDTO>>(jsonData);
            return View(values);
        }
        return View();
    }
}
