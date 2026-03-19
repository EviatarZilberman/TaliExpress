using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class GetStoreResponse
    {
        public StoreDbModel Store { get; set; } = new StoreDbModel();
    }
}
