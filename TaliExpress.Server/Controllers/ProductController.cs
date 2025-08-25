using Microsoft.AspNetCore.Mvc;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("searchProduct")]
        public IActionResult SearchProduct([FromBody] string productDescription)
        {
            return Ok();
        }
    }
}
