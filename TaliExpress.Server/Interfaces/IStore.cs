using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface IStore
    {
        public OpenStoreResponse OpenStore(OpenStoreRequest request);
        public GetStoreResponse GetStore(HttpContext httpContext);
    }
}
