using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        //public string Get()
        //{
        //    return "Hi dear";
        //}
        public IActionResult Get() 
        { 
            return Ok("Vamsi");
        }
    }
}
