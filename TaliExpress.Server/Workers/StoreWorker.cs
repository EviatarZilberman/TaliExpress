using Microsoft.AspNetCore.Http;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class StoreWorker : IStore
    {
        public OpenStoreResponse OpenStore(OpenStoreRequest request, HttpContext httpContext)
        {
            string a = httpContext.User.FindFirst(CookiesKeys.ID.ToString())?.Value!;

            Store store = new Store
            {
                Name = request.StoreName,
                Username = request.OwnerEmail,
            };

            OpenStoreResponse response = new OpenStoreResponse();
            StoresManager storesManager = new StoresManager();
            if (storesManager.Insert(store))
            {
                response.Code = (int)ReturnCode.Success;
                return response;
            }
            return response;
        }
    }
}