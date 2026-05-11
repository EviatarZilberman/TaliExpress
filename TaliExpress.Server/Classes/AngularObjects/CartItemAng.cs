using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class CartItemAng
    {
        [JsonPropertyName("product")]
        public ProductAng Product { get; set; } = new ProductAng();
        [JsonPropertyName("amount")]
        public int Amount { get; set; } = 0;
    }
}
