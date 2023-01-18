using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestQuala.WebApi.Controllers
{

    public class TestController : Controller
    {

        public TestController()
        {
           
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Test")]
        public ActionResult Test()
        {
            return Ok("Running");
        }
     

      

    }

}
