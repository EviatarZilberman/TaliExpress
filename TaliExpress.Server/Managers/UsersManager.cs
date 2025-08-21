using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Managers
{
    public class UsersManager : AManager<User>
    {
        public override ReturnCode Delete([FromBody] string userId)
        {
            throw new NotImplementedException();
        }

        public override ReturnCode Get([FromBody] string userId, ref User? user)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return ReturnCode.General_Error;
            }
            FilterDefinition<User> filter = FilterCreator<User>.CreateFilter(AttributesAndWords.Email.ToString(), userId);
            if (MongoDBServiceManager<User>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Users.ToString()).Get(filter, out User? tempUser) == MongoDBReturnCodes.Success)
            {
                user = tempUser;
                return ReturnCode.Success;
            }
            else
            {
                return ReturnCode.General_Error;
            }
        }

        public override ReturnCode GetAll(ref List<User>? users)
        {
            if (MongoDBServiceManager<User>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Users.ToString()).GetAll(out List<User>? tempUsers) == MongoDBReturnCodes.Success)
            {
                users = tempUsers ?? null;
                return ReturnCode.Success;
            }
            return ReturnCode.General_Error;
        }

        public override async Task<ReturnCode> Insert(User user)
        {
            if (user == null)
            {
                return ReturnCode.General_Error;
            }

            Task<MongoDBReturnCodes> res = MongoDBServiceManager<User>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Users.ToString()).Insert(user);
            if (await res == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            else
            {
                return ReturnCode.General_Error;
            }
        }

        public override ReturnCode Update([FromBody] User user)
        {
            try
            {
                MongoDBServiceManager<User>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionNames.Users.ToString()).Update(user);
                return ReturnCode.Success;
            }
            catch
            {
                return ReturnCode.General_Error;
            }
        }
    }
}
