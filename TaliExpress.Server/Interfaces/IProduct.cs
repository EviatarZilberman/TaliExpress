using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface IProduct
    {
        public Task<BaseApiResponse> AddProduct([FromBody] AddProductRequest request);
    }
}
