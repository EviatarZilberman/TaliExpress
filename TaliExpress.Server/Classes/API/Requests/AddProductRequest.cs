using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class AddProductRequest
    {
        [JsonPropertyName("userId")]
        public string SellerId { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public double Price { get; set; } = 0;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; } = new List<string>();
        [JsonPropertyName("amountInInvenotry")]
        public int AmountInInvenotry { get; set; } = 0;
        [JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; } = false;
        [JsonPropertyName("discount")]
        public double Discount { get; set; } = 0;
    }
}
