using System.Text.Json.Serialization;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public class StoreAng : BaseAngOwner, IAdapt<StoreDbModel>
    {
        [JsonPropertyName("products")]
        public List<ProductAng> Products { get; set; } = new List<ProductAng>();
        [JsonPropertyName("storeName")]
        public string StoreName { get; set; } = string.Empty;
        [JsonPropertyName("shipTo")]
        public string[] ShipTo { get; set; } = new string[] { "All" };

        public void Adapt(StoreDbModel item)
        {
            this.Id = item.Id.ToString();
            this.userId = item.UserId.ToString();
            this.ShipTo = item.ShipTo;
            this.StoreName = item.StoreName;
            for (int i = 0;  i < item.Products.Count; i++)
            {
                ProductAng productAng = new ProductAng();
                productAng.Adapt(item.Products[i]);
                this.Products.Add(productAng);
                
            }
        }
    }
}