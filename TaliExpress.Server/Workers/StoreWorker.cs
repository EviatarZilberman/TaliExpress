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
        public GetStoreResponse GetStore(HttpContext httpContext)
        {
            string userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == CookiesKeys.ID.ToString())?.Value!;
            if (string.IsNullOrEmpty(userId))
            {
                return new GetStoreResponse();
            }
            StoresManager storesManager = new StoresManager();
            if (!storesManager.GetById(storesManager.GetCollectionName(), userId, out StoreDbModel store))
            {
                return new GetStoreResponse();
            }

            return new GetStoreResponse
            {
                Store = store
            };
        }

        public OpenStoreResponse OpenStore(OpenStoreRequest request)
        {
            StoreDbModel store = new StoreDbModel
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

        public StoreExistResponse StoreExist(HttpContext httpContext)
        {
            string userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == CookiesKeys.ID.ToString())?.Value!;
            StoresManager storesManager = new StoresManager();
            if (!storesManager.GetById(storesManager.GetCollectionName(), userId, out StoreDbModel store))
            {
                return new StoreExistResponse();
            }

            return new StoreExistResponse
            {
                code = (int)ReturnCode.Success,
                hasStore = true
            };
        }
    }
}