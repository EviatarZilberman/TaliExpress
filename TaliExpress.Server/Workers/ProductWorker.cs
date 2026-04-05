using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;

namespace TaliExpress.Server.Workers
{
    public sealed class ProductWorker : IProduct
    {
        public async Task<BaseApiResponse> AddProduct(AddProductRequest request)
        {
            if (request == null || request.Product == null) return new BaseApiResponse
            {
                Code = -1
            };

            ProductManager productManager = new ProductManager();
            productManager.Insert(productManager.GetCollectionName(), request.Product);
            return new BaseApiResponse();
        }
    }
}
