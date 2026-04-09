using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public sealed class ProductWorker : IProduct
    {
        public async Task<BaseApiResponse> AddProduct(AddProductRequest request)
        {
            if (request == null) return new BaseApiResponse
            {
                Code = -1
            };

            ProductDbModel productDbModel = new ProductDbModel()
            {
                AmountInInvenotry = request.AmountInInvenotry,
                Categories = request.Categories,
                Description = request.Description,
                Discount = request.Discount,
                IsAvailable = request.IsAvailable,
                Name = request.Name,
                Price = request.Price,
                UserId = request.SellerId
            };

            ProductsManager productManager = new ProductsManager();
            productManager.Insert(productManager.GetCollectionName(), productDbModel);
            return new BaseApiResponse();
        }
    }
}
