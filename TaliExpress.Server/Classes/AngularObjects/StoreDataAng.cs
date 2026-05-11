using System.Text.Json.Serialization;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class StoreDataAng : IAdapt<StoreDbModel>
    {
        [JsonPropertyName("amountOfProducts")]
        public int AmountOfProducts { get; set; } = 0;


        public void Adapt(StoreDbModel item)
        {
            this.AmountOfProducts = item.Products.Count;
        }
    }
}