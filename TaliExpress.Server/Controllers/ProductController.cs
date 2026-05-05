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

        [HttpPost("addProduct")]
        public async Task<BaseApiResponse> AddProduct([FromBody] AddProductRequest request)
        {
            return await this.ProductWorker.AddProduct(request);
        }

        [HttpPost("updateProduct")]
        public async Task<BaseApiResponse> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            return await this.ProductWorker.UpdateProduct(request);
        }
    }
}