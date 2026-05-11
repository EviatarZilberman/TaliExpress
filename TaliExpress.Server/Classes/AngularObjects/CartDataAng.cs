using System.Text.Json.Serialization;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class CartDataAng: IAdapt<CartDbModel>
    {
        [JsonPropertyName("amountOfItems")]
        public int AmountOfItems { get; set; } = 0;

        public void Adapt(CartDbModel item)
        {
            this.AmountOfItems = item.Products.Count;
        }
    }
}