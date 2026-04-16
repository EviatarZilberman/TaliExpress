using System.Text.Json.Serialization;
using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class SearchResponse : BaseApiResponse
    {
        [JsonPropertyName("products")]
        public List<ProductAng> Products { get; set; } = new List<ProductAng>();
    }
}
