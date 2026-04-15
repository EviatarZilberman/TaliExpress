using MongoDB.Bson;
using System.Text.Json.Serialization;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class CartAng : BaseAngOwner, IAdapt<CartDbModel>
    {
        [JsonPropertyName("products")]
        public Dictionary<string, int> Products { get; set; } = new Dictionary<string, int>();

        public void Adapt(CartDbModel item)
        {
            foreach(KeyValuePair<ObjectId, int> kvp in item.Products)
            {
                this.Products.Add(kvp.Key.ToString(), kvp.Value);
            }
        }
    }
}