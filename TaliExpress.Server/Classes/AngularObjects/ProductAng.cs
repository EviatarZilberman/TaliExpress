using System.Text.Json.Serialization;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class ProductAng : BaseAngOwner, IAdapt<ProductDbModel>
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

        public void Adapt(ProductDbModel item)
        {
            this.Id = item.Id.ToString();
            this.userId = item.UserId.ToString();
            this.AmountInInvenotry = item.AmountInInvenotry;
            this.Categories = item.Categories;
            this.CreatedAt = item.CreationDate;
            this.Description = item.Description;
            this.Discount = item.Discount;
            this.IsAvailable = item.IsAvailable;
            this.Name = item.Name;
            this.Price = item.Price;
        }
    }
}