using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HostelManagementApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public LoginController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        public IActionResult UserLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult UserLogin([FromForm] UserProfile userProfile)
        {
            var result = _userProfileRepository.Login(userProfile);

            if (result != null)
            {

                //authentication is success
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("security@123456789");
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, result.Email),
                        new Claim(ClaimTypes.Role, result.FkroleId.ToString()),

                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwttoken = tokenHandler.WriteToken(token);

                // Set the token in the response header
                //Response.Headers.Add("Authorization", "Bearer " + jwttoken);
                // set the JWT token in the response cookie
                Response.Cookies.Append("jwt", jwttoken, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
                return RedirectToAction("Index", "UserProfiles");

            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
    }
}
