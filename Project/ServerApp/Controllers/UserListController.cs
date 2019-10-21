using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Domain;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private IServerDataRuntime _dataRuntime;

        public UserListController(IUnitOfWork unitOfWork, IServerDataRuntime dataRuntime)
        {
            _unitOfWork = unitOfWork;
            _dataRuntime = dataRuntime;
        }
        
        [HttpPost]
        public ActionResult<List<User>> PostUserList(Token token)
        {
            var iscorrect = _dataRuntime.CheckToken(token.Key);
            
            if (iscorrect)
            {
                if (_unitOfWork.UsersRepository == null)
                {
                    throw new Exception("UsersRepository NULL");
                }

             
                    var users = _unitOfWork.UsersRepository.GetListUsersDescending();
                    
                
                    return Ok(users);
            
                throw new Exception("nullRepo");
            }


            return StatusCode(700);
        }
        
    }
}