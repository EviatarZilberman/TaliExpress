using System.Text.Json.Serialization;
using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class OpenStoreResponse : BaseApiResponse
    {
        [JsonPropertyName("store")]
        public StoreAng Store { get; set; } = new StoreAng();
    }
}