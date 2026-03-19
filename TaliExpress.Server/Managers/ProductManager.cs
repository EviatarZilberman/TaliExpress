using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class ProductManager : MongoDBServiceManager
    {
        public new string GetCollectionName() => "products";
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
    }
}
