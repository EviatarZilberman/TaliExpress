using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class StoresManager : AManager<Store>
    {
        public override ReturnCode Delete(string id)
        {
            throw new NotImplementedException();
        }

        public override ReturnCode Get(string commonId, out Store? item)
        {
            return this.Get(commonId, out item);
        }

        public override ReturnCode GetAll(ref List<Store>? items)
        {
            throw new NotImplementedException();
        }

        public override async Task<ReturnCode> Insert(Store item)
        {
            if (item == null)
            {
                return ReturnCode.General_Error;
            }

            Task<MongoDBReturnCodes> res = MongoDBServiceManager<Store>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Stores.ToString()).Insert(item);
            if (await res == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            else
            {
                return ReturnCode.General_Error;
            }
        }

        public override ReturnCode Update(Store item)
        {
            throw new NotImplementedException();
        }
    }
}