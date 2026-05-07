using System.Linq.Expressions;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public sealed class CartWorker : ICart
    {
        public async Task<BaseApiResponse> AddToCart(AddToCartRequest request, HttpContext httpContext)
        {
            try
            {
                string userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == CookiesKeys.ID.ToString())?.Value!;

                CartManager cartManager = new CartManager();
                if (!cartManager.GetByUserId(userId, out CartDbModel cartDbModel))
                {
                    cartDbModel = new CartDbModel();
                    cartDbModel.UserId = userId;
                    cartManager.Insert(cartDbModel);
                }

                if (cartDbModel.Products.Any(p => p.Key.ToString() == request.ProductId))
                {
                    cartDbModel.Products[request.ProductId] += request.Amount;
                }
                else
                {
                    cartDbModel.Products.Add(request.ProductId, request.Amount);
                }
                if (!cartManager.Update(cartDbModel))
                {
                    return new BaseApiResponse()
                    {
                        Code = -1,
                        Message = "An error occurred while adding the product to the cart"
                    };
                }
                return new BaseApiResponse()
                {
                    Code = 0,
                    Message = "Product added to cart successfully!"
                };
            }
            catch
            {
                return new BaseApiResponse()
                {
                    Code = -1,
                    Message = "An error occurred while adding the product to the cart"
                };
            }
        }
    }
}
