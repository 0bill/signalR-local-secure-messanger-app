using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DatabaseMS;

namespace Server.Controllers
{
    public class LoginController : ApiController
    {
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public IHttpActionResult PostNewStudent(User user)
        {
            var user1 = new Test().GetUser();


            return Ok(user1.Username);
        }



    }
}
