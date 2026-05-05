using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class AddToCartRequest
    {
        [JsonPropertyName("productId")]
        public string ProductId { get; set; } = string.Empty;
        [JsonPropertyName("amount")]
        public int Amount { get; set; } = 1;
    }
}
