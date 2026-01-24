using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class StoreWorker : IStore
    {
        public Task<OpenStoreResponse> OpenStore(OpenStoreRequest request)
        {
            Store store = new Store
            {
                Name = request.StoreName,
                Username = request.OwnerEmail,
            };

            StoresManager storesManager = new StoresManager();
            return storesManager.Insert(store).ContinueWith(task =>
            {
                OpenStoreResponse response = new OpenStoreResponse();
                response.Code = (int)task.Result;
                return response;
            });
        }
    }
}