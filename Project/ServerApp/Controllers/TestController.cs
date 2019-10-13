using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}
