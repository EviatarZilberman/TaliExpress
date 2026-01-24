using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface IStore
    {
        public Task<OpenStoreResponse> OpenStore(OpenStoreRequest request);
    }
}
