using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class CartManager : MongoDBServiceManager<Cart>
    {
        public new bool Delete(string id) => base.Delete(id);

        public bool GetByOwnerId(string commonId, out Cart? item) => base.FindOneByProperty("Username", commonId, out item);

        public new bool GetAll(out List<Cart> items) => base.GetAll(out items);

        public new bool Insert(Cart item) => base.Insert(item);

        public bool AddProduct(string cartId, Product product, int amount = 0)
        { 
            if (!this.GetById(cartId, out Cart cart)) return false;
            cart.Products.Add(product.Id, amount);
            return this.Replace(cart);
        }

        public bool RemoveProduct(string cartId, Product product, int amount = 0)
        {
            if (!this.GetById(cartId, out Cart cart)) return false;
            cart.Products.Remove(product.Id);
            return this.Replace(cart);
        }

        public bool RemoveAllProducts(string cartId)
        {
            if (!this.GetById(cartId, out Cart cart)) return false;
            cart.Products.Clear();
            return this.Replace(cart);
        }
    }
}