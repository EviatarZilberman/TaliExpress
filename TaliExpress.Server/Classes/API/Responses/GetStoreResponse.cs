using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class GetStoreResponse
    {
        public int Code { get; set; } = -1;
        public StoreAng Store { get; set; } = new StoreAng();
    }
}