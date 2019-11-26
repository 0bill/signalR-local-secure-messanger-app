using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;

namespace ServerApp.Controllers
{
    /// <summary>
    /// Controller handle all request related to users
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserListController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Return list of users
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<List<User>> PostUserList()
        {
            
                    var users = _unitOfWork.UsersRepository.GetListUsersDescending();
                    return Ok(users);
           
        }
        
    }
}