using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class GetStoreResponse
    {
        public int Code { get; set; } = -1;
        public StoreDbModel Store { get; set; } = new StoreDbModel();
    }
}
