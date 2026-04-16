using TaliExpress.Server.Classes.AngularObjects;
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
            if (!storesManager.GetByUserId(userId, out StoreDbModel store))
            {
                return new GetStoreResponse();
            }

            ProductsManager productManager = new ProductsManager();
            productManager.GetAllBySellerId(store.UserId, out List<ProductDbModel>? products);
            store.Products = products!;
            StoreAng storeAng = new StoreAng();
            if (store != null) storeAng.Adapt(store);
            return new GetStoreResponse
            {
                Code = 0,
                Store = storeAng
            };
        }

        public OpenStoreResponse OpenStore(HttpContext httpContext, OpenStoreRequest request)
        {
            string userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == CookiesKeys.ID.ToString())?.Value!;
            if (string.IsNullOrEmpty(userId))
            {
                return new OpenStoreResponse
                {
                    Code = -1
                };
            }
            StoreDbModel store = new StoreDbModel
            {
                StoreName = request.StoreName,
                UserId = userId,
            };

            OpenStoreResponse response = new OpenStoreResponse();
            StoresManager storesManager = new StoresManager();
            StoreAng storeAng = new StoreAng();
            storeAng.Adapt(store);
            if (storesManager.Insert(store))
            {
                response.Code = (int)ReturnCode.Success;
                response.Store = storeAng;
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