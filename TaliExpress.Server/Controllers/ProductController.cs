using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("searchProduct")]
        public IActionResult SearchProduct([FromQuery] string productDescription)
        {
            List<ProductDbModel> products = new List<ProductDbModel>();
            products.Add(new ProductDbModel()
            {
                IsAvailable = true,
                Name = "1",
                Description = "productDescription1",
                SellerId = "1",
                Price = 1
            });
            products.Add(new ProductDbModel()
            {
                IsAvailable = true,
                Name = "2",
                Description = "productDescription2",
                SellerId = "2",
                Price = 1
            });
            return Ok(products);
        }
    }
}
