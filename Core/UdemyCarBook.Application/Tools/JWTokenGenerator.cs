using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.DTO.TokenResponseDTOs;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;

namespace UdemyCarBook.Application.Tools;
public class JWTokenGenerator
{
	public static TokenResponseDTO GenerateToken(GetCheckAppUserQueryResult result)
	{
		var claims = new List<Claim>();
		if (!string.IsNullOrEmpty(result.Role))
			claims.Add(new Claim(ClaimTypes.Role, result.Role));

		claims.Add(new Claim(ClaimTypes.NameIdentifier, result.AppUserID.ToString()));

		if(!string.IsNullOrEmpty(result.Username))
			claims.Add(new Claim("Username", result.Username));

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTokenDefault.IssuerSigningKey));
		var signinCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

		var exprireDate = DateTime.UtcNow.AddDays(JWTokenDefault.Expire);

		JwtSecurityToken token = new JwtSecurityToken(
			issuer: JWTokenDefault.IssuerSigningKey,
			audience: JWTokenDefault.ValidAuidence,
			claims: claims,
			notBefore: DateTime.UtcNow,
			expires: exprireDate,
			signingCredentials: signinCredentials);

		JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
		return new TokenResponseDTO(tokenHandler.WriteToken(token), exprireDate);

	}
}
