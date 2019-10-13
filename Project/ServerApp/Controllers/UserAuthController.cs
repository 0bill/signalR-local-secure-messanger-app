using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        // POST: api/UserAuth
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
       
    }
}
