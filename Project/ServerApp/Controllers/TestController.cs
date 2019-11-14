using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _config;
        public TestController(IConfiguration config)
        {
            _config = config;
        }
        // GET: api/Test
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
        

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            //TODO:CHECK USER LOGIN
            if (false) //User login failed
                return Ok();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://localhost:5001",
                Audience = "https://localhost:5001",
                
                Subject = new ClaimsIdentity(new Claim[]{
                    //TODO: SET USERID
                    new Claim(ClaimTypes.NameIdentifier,"ID"),
                    //TODO: SET USERNAME
                    new Claim(ClaimTypes.Name, "USERNAME")
                }),
                
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { tokenString });
        }

   
    }
}
