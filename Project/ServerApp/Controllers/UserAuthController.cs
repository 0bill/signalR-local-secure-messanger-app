using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Database;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServerDataRuntime _dataRuntime;
        private readonly IConfiguration _config;


        public UserAuthController(IUnitOfWork unitOfWork, IServerDataRuntime dataRuntime, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _dataRuntime = dataRuntime;
            _config = config;
        }


        // POST: api/UserAuth
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            var confirmedUser = _unitOfWork.LoginUserRepository.IsLoginUserValid(user);
            if (confirmedUser != null)
            {
                confirmedUser.Token = new Token();
                confirmedUser.Token.UserId = confirmedUser.Id;
                confirmedUser.Token.JwtToken =   GenerateToken(confirmedUser.Id,confirmedUser.Username);
                confirmedUser.Token.RefreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                _dataRuntime.AddToken(confirmedUser.Token);

                //_dataRuntime.AddConnectedUser(confirmedUser);
                return Ok(confirmedUser);
            }

            return BadRequest();
        }

        [HttpPost("refresh")]
        public ActionResult<User> PostRefreshToken(Token token)
        {
            
            if (_dataRuntime.CheckRefreshToken(token))
            {
                var userId = token.UserId;
        
                var jwtSecurityToken = new JwtSecurityToken(token.JwtToken);
                var claim = jwtSecurityToken.Claims.SingleOrDefault(x => x.Type == "unique_name");

                _dataRuntime.RemoveToken(token);
                var newToken = new Token();
                newToken.UserId = userId;
                newToken.JwtToken =   GenerateToken(userId, claim.Value);
                newToken.RefreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                _dataRuntime.AddToken(newToken);

                return Ok(newToken);
            }
            return BadRequest();
        }

        private string GenerateToken(int userId, string username)
        {
            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "https://localhost:5001",
                Audience = "https://localhost:5001",
                Subject = new ClaimsIdentity(new Claim[]{
                    //TODO: SET USERID
                    new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                    //TODO: SET USERNAME
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            return tokenString;
        }
    }
}

