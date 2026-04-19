using Microsoft.AspNetCore.Mvc;
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
            string userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == CookiesKeys.ID.ToString())?.Value!;

            CartManager cartManager = new CartManager();
            if (!cartManager.GetByUserId(userId, out CartDbModel cartDbModel))
            {
                cartDbModel = new CartDbModel();
                cartDbModel.UserId = userId;
            }

            cartDbModel.Products.TryGetValue(new MongoDB.Bson.ObjectId(request.productId), out int amount);
            cartManager.Upsert(cartDbModel);
            return new BaseApiResponse();
        }
    }
}
