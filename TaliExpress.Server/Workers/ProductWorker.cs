using Microsoft.AspNetCore.Mvc;
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

        public async Task<BaseApiResponse> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            if (request == null) return new BaseApiResponse
            {
                Code = -1
            };

            ProductsManager productManager = new ProductsManager();
            if (!productManager.GetById(request.productAng.Id, out ProductDbModel productDbModel))
            {
                return new BaseApiResponse
                {
                    Code = -1,
                    Message = "Product not found or you are not the owner of this product."
                };
            }

            productDbModel.AmountInInvenotry = request.productAng.AmountInInvenotry;
            productDbModel.Categories = request.productAng.Categories;
            productDbModel.Description = request.productAng.Description;
            productDbModel.Discount = request.productAng.Discount;
            productDbModel.IsAvailable = request.productAng.IsAvailable;
            productDbModel.Name = request.productAng.Name;
            productDbModel.Price = request.productAng.Price;

            productManager.Replace(productDbModel);
            return new BaseApiResponse();
        }
    }
}