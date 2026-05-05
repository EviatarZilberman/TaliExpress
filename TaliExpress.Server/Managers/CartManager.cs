using MongoDBService.Classes;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class CartManager : AManager
    {
        public bool Delete(string id) => base.Delete<CartDbModel>(this.GetCollectionName(), id);

        public bool GetByUserId(string userId, out CartDbModel item) => base.FindOneByProperty<CartDbModel>(this.GetCollectionName(), "UserId", userId, out item);

        public bool GetAll(out List<CartDbModel> items) => base.GetAll(this.GetCollectionName(), out items);

        public bool Insert(CartDbModel item) => base.Insert(this.GetCollectionName(), item);

        public bool AddProduct(string cartId, ProductDbModel product, int amount = 0)
        { 
            if (!this.GetById(this.GetCollectionName(), cartId, out CartDbModel cart)) return false;
            cart.Products.Add(product.Id.ToString(), amount);
            return this.Replace(this.GetCollectionName(), cart);
        }

        public bool RemoveProduct(string cartId, ProductDbModel product, int amount = 0)
        {
            if (!this.GetById(this.GetCollectionName(), cartId, out CartDbModel cart)) return false;
            cart.Products.Remove(product.Id.ToString());
            return this.Replace(this.GetCollectionName(), cart);
        }

        public bool RemoveAllProducts(string cartId)
        {
            if (!this.GetById(this.GetCollectionName(), cartId, out CartDbModel cart)) return false;
            cart.Products.Clear();
            return this.Replace(this.GetCollectionName(), cart);
        }

        public bool Update(CartDbModel item) => base.Replace(item);

        public override string GetCollectionName() => "carts";
    }
}