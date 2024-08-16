namespace UdemyCarBook.WebUI.Models;

public class JWTReponseModel
{
    public string Token { get; set; }
    public DateTimeOffset ExpireDate { get; set; }
}
