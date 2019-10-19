using System;
using System.Net.Http;
using System.Threading.Tasks;
using Database;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // POST: api/UserAuth
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {

            if (_unitOfWork.UserRepository.IsLoginUserValid(user))
            {
                user.Username = Guid.NewGuid().ToString();
                return Ok(user);
            }
            return BadRequest();

        }

    }
}
