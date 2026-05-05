using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface ICart
    {
        public Task<BaseApiResponse> AddToCart(AddToCartRequest request, HttpContext httpContext);

    }
}