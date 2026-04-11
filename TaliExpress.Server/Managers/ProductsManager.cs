using MongoDB.Driver;
using MongoDBService.Classes;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class ProductsManager : AManager
    {
        public override string GetCollectionName() => "products";
        public ReturnCode GetFiltered(FilterDefinition<ProductDbModel> filters, out List<ProductDbModel>? products)
        {
            //if (string.IsNullOrEmpty(productId))
            //{
            //    products = null;
            //    return ReturnCode.No_parameters_entered;
            //}
            if (this.FindManyByProperty(this.GetCollectionName(), "Name", "aaa", out products))
            {
                return ReturnCode.Success;
            }
            else
            {
                products = null;
                return ReturnCode.General_Error;
            }
        }

        public bool GetBySellerId(string sellerId, out List<ProductDbModel>? products)
        {
            return this.FindManyByProperty(this.GetCollectionName(), "UserId", sellerId, out products);
        }
    }
}