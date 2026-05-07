using MongoDB.Bson;
using System.Text.Json.Serialization;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class CartAng : BaseAngOwner, IAdapt<CartDbModel>
    {
        [JsonPropertyName("products")]
        public Dictionary<ProductAng, int> Products { get; set; } = new Dictionary<ProductAng, int>();

        public void Adapt(CartDbModel item)
        {
            ProductsManager productsManager = new ProductsManager();
            foreach(string productId in item.Products.Keys)
            {
                productsManager.GetById(productId, out ProductDbModel product);
                this.Products.Add(new ProductAng() { 
                    Id = productId,
                    AmountInInvenotry = product.AmountInInvenotry,
                    Categories = product.Categories,
                    CreatedAt = product.CreationDate,
                    Description = product.Description,
                    Discount = product.Discount,
                    IsAvailable = product.IsAvailable,
                    Name = product.Name,
                    Price = product.Price,
                    userId = product.UserId
                }, item.Products[productId]);
            }
        }
    }
}