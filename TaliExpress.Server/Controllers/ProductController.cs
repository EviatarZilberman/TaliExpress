using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Controllers.Common;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    public class ProductController : OriginController
    {
        private readonly IProduct ProductWorker;

        public ProductController(IProduct productWorker)
        {
            this.ProductWorker = productWorker;
        }

        [HttpGet("searchProduct")]
        public IActionResult SearchProduct([FromQuery] string productDescription)
        {
            List<ProductDbModel> products = new List<ProductDbModel>();
            products.Add(new ProductDbModel()
            {
                IsAvailable = true,
                Name = "1",
                Description = "productDescription1",
                UserId = "1",
                Price = 1
            });
            products.Add(new ProductDbModel()
            {
                IsAvailable = true,
                Name = "2",
                Description = "productDescription2",
                UserId = "2",
                Price = 1
            });
            return Ok(products);
        }

        [HttpPost("addProduct")]
        public async Task<BaseApiResponse> AddProduct([FromBody] AddProductRequest request)
        {
            return await this.ProductWorker.AddProduct(request);
        }
    }
}
