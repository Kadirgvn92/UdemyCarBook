using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.DTO.TokenResponseDTOs;
public class TokenResponseDTO
{
    public TokenResponseDTO(string token, DateTime expiredDate)
    {
        Token = token;
		ExprireDate = expiredDate;
    }
    public string  Token { get; set; }
    public DateTime ExprireDate { get; set; }
}
