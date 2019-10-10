using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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
        


            return Ok();
        }



    }
}
