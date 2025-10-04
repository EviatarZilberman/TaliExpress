using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class ProductManager : AManager<Product>
    {
        public override ReturnCode Delete([FromBody] string productId)
        {
            if (string.IsNullOrEmpty(productId)) return ReturnCode.Parameter_is_null_or_empty;
            if (MongoDBServiceManager<User>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Products.ToString()).Delete(productId) == MongoDBReturnCodes.Success) return ReturnCode.Success;
            return ReturnCode.General_Error;

        }

        public override ReturnCode Get([FromBody] string productId, out Product? product)
        {
            if (string.IsNullOrEmpty(productId))
            {
                product = null;
                return ReturnCode.General_Error;
            }
            FilterDefinition<Product> filter = FilterCreator<Product>.CreateEqualFilter(AttributesAndWords.Username.ToString(), productId);
            if (MongoDBServiceManager<Product>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Products.ToString()).Get(filter, out Product? tempProduct) == MongoDBReturnCodes.Success)
            {
                product = tempProduct;
                return ReturnCode.Success;
            }
            else
            {
                product = null;
                return ReturnCode.General_Error;
            }
        }

        public override ReturnCode GetAll(ref List<Product>? users)
        {
            if (MongoDBServiceManager<Product>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Products.ToString()).GetAll(out List<Product>? tempProducts) == MongoDBReturnCodes.Success)
            {
                users = tempProducts ?? null;
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }

        public override async Task<ReturnCode> Insert(Product product)
        {
            if (product == null)
            {
                return ReturnCode.General_Error;
            }

            Task<MongoDBReturnCodes> res = MongoDBServiceManager<Product>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Products.ToString()).Insert(product);
            if (await res == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            else
            {
                return ReturnCode.General_Error;
            }
        }

        public override ReturnCode Update([FromBody] Product user)
        {
            try
            {
                MongoDBServiceManager<Product>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Users.ToString()).Update(user);
                return ReturnCode.Success;
            }
            catch
            {
                return ReturnCode.General_Error;
            }
        }


    }
}
