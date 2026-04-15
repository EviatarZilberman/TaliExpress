using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class UpdateProductRequest : AddProductRequest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
    }
}
