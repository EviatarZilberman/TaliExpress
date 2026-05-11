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
        public Dictionary<int, CartItemAng> CartItemsAng { get; set; } = new Dictionary<int, CartItemAng>();

        public void Adapt(CartDbModel item)
        {
            this.Id = item.Id.ToString();
            this.userId = item.UserId.ToString();
            ProductsManager productsManager = new ProductsManager();
            int counter = 1;
            foreach (string productId in item.Products.Keys)
            {
                productsManager.GetById(productId, out ProductDbModel product);
                this.CartItemsAng.Add(counter, new CartItemAng
                {
                    Product = new ProductAng()
                    {
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
                    },
                    Amount = item.Products[productId]
                });
                counter++;
            }
        }
    }
}