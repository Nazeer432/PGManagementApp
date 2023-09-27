using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HostelManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("Authentication")]
        public IActionResult Authentication([FromForm] UserProfile user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))

                return Unauthorized();

            if (user.Email == user.Password)
            {
                //authentication is success
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("security@123456789");
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Role, "Manager")

                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwttoken = tokenHandler.WriteToken(token);
                return Ok(jwttoken);
            }
            return Unauthorized();

        }
    }
}
