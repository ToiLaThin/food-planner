using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("auth")]
public class AuthController: ControllerBase
{
    [AllowAnonymous]
    [Route("login")]
    [HttpGet]
    public IActionResult Login()
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "peter"),
            new Claim(ClaimTypes.Role, "admin"),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_secret_key_123super_secret_key_123super_secret_key_123super_secret_key_123super_secret_key_123super_secret_key_123"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(claims: claims, signingCredentials: credentials, expires: DateTime.Now.AddMinutes(1));
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return Ok(jwt);
    }
}