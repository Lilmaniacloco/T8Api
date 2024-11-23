using Microsoft.AspNetCore.Http;
using DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using T8Api.DTO;

namespace T8Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<AppUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInAsync(LoginRequest request)
        {
            AppUser? user = await userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return Unauthorized("Username Bad");
            }

            bool success = await userManager.CheckPasswordAsync(user, request.Password);

            if (!success)
            {
                return Unauthorized("Password Bad");
            }

            JwtSecurityToken token = await jwtHandler.GetSecurityTokenAsync(user);

            string jwtString = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponse response = new()
            {
                Success = true,
                Message = "I Need help",
                Token = jwtString
            };

            return Ok(response);
        }
    }
}
