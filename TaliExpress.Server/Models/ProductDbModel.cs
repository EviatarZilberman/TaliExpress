using MongoDBService.Classes;
using System.Text.Json.Serialization;

namespace TaliExpress.Server.Models
{
    public class ProductDbModel : UserOwner
    {
        [JsonPropertyName("price")]
        public double Price { get; set; } = 0;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        //public string ImageUrl { get; set; } = string.Empty;
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