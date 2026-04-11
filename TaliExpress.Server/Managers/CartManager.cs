using MongoDBService.Classes;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class CartManager : AManager
    {
        public bool Delete(string id) => base.Delete<Cart>(this.GetCollectionName(), id);

        public bool GetByUserId(string userId, out Cart? item) => base.FindOneByProperty<Cart>(this.GetCollectionName(), "UserId", userId, out item);

        public bool GetAll(out List<Cart> items) => base.GetAll(this.GetCollectionName(), out items);

        public bool Insert(Cart item) => base.Insert(this.GetCollectionName(), item);

        public bool AddProduct(string cartId, ProductDbModel product, int amount = 0)
        { 
            if (!this.GetById(this.GetCollectionName(), cartId, out Cart cart)) return false;
            cart.Products.Add(product.Id, amount);
            return this.Replace(this.GetCollectionName(), cart);
        }

        public bool RemoveProduct(string cartId, ProductDbModel product, int amount = 0)
        {
            if (!this.GetById(this.GetCollectionName(), cartId, out Cart cart)) return false;
            cart.Products.Remove(product.Id);
            return this.Replace(this.GetCollectionName(), cart);
        }

        public bool RemoveAllProducts(string cartId)
        {
            if (!this.GetById(this.GetCollectionName(), cartId, out Cart cart)) return false;
            cart.Products.Clear();
            return this.Replace(this.GetCollectionName(), cart);
        }

        public override string GetCollectionName() => "carts";
    }
}