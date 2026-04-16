using System.Text.Json.Serialization;
using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class UpdateProductRequest
    {
        [JsonPropertyName("product")]
        public ProductAng productAng { get; set; } = new ProductAng();
    }
}