using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using UdemyCarBook.DTO.LoginDTOs;
using UdemyCarBook.DTO.RegisterDTOs;
using UdemyCarBook.WebUI.Models;

namespace UdemyCarBook.WebUI.Controllers;
public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginDTO dTO)
    {
        var client = _httpClientFactory.CreateClient();
        var content = new StringContent(JsonSerializer.Serialize(dTO), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:44323/api/SignIn", content);
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var tokenModel = JsonSerializer.Deserialize<JWTReponseModel>(jsonData , new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if(tokenModel != null)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var tokenHandler = handler.ReadJwtToken(tokenModel.Token);
                var claims = tokenHandler.Claims.ToList();
                if(tokenModel.Token != null)
                {
                    claims.Add(new Claim("accessToken", tokenModel.Token));
                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                    var autProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), autProps);
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                }

            }
        }
        return View();
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Default");
    }
}
