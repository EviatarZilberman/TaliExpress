using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class CartManager : AManager<Cart>
    {
        public override ReturnCode Delete([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return ReturnCode.General_Error;
            }
            FilterDefinition<Cart> filter = FilterCreator<Cart>.CreateEqualFilter(AttributesAndWords.Username.ToString(), id);
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Delete(id) == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            else
            {
                return ReturnCode.General_Error;
            }
        }

        public override ReturnCode Get([FromBody] string commonId, out Cart? item)
        {
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Get(commonId, out Cart? cart) == MongoDBReturnCodes.Success)
            {
                item = cart;
                return ReturnCode.Success;
            }
            item = null;
            return ReturnCode.General_Error;
        }

        public override ReturnCode GetAll(ref List<Cart>? items)
        {
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).GetAll(out List<Cart> carts) == MongoDBReturnCodes.Success)
            {
                items = carts;
                return ReturnCode.Success;
            }
            items = null;
            return ReturnCode.General_Error;
        }

        public override async Task<ReturnCode> Insert(Cart item)
        {
            if (await MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Insert(item) == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }

        public override ReturnCode Update([FromBody] Cart item)
        {
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Update(item) == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }

        public ReturnCode AddProduct(string cartId, Product product, int amount = 0)
        {
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Get(cartId, out Cart? cart) == MongoDBReturnCodes.Success)
            {
                if (cart == null) return ReturnCode.No_cart_found;
                if (amount == 0) amount++;
                cart.Products.Add(product.Id, amount);
                this.Update(cart);
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }

        public ReturnCode RemoveProduct(string cartId, Product product, int amount = 0)
        {
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Get(cartId, out Cart? cart) == MongoDBReturnCodes.Success)
            {
                if (cart == null) return ReturnCode.No_cart_found;
                if (amount == 0) amount--;
                cart.Products.Add(product.Id, amount);
                this.Update(cart);
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }

        public ReturnCode RemoveAllProducts(string cartId)
        {
            if (MongoDBServiceManager<Cart>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Carts.ToString()).Get(cartId, out Cart? cart) == MongoDBReturnCodes.Success)
            {
                if (cart == null) return ReturnCode.No_cart_found;
                cart.Products.Clear();
                this.Update(cart);
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }
    }
}