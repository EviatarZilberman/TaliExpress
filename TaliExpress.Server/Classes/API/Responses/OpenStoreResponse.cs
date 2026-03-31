using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class OpenStoreResponse : BaseApiResponse
    {
        public StoreDbModel store { get; set; } = new StoreDbModel();
    }
}