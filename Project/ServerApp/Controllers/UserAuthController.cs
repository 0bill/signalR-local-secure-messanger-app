using System;
using System.Net.Http;
using System.Threading.Tasks;
using Database;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServerDataRuntime _dataRuntime;

        public UserAuthController(IUnitOfWork unitOfWork, IServerDataRuntime dataRuntime)
        {
            _unitOfWork = unitOfWork;
            _dataRuntime = dataRuntime;
        }



        // POST: api/UserAuth
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            if (_unitOfWork.UserRepository.IsLoginUserValid(user))
            {
                user.Token = Guid.NewGuid().ToString();
                _dataRuntime.addConnectedUser(user);
                return Ok(user.Token);
            }
            return BadRequest();

        }

    }
}
