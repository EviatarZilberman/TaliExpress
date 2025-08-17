using ConfigApp.Classes;
using Microsoft.AspNetCore.Mvc;
using MongoDBService.Classes;
using MongoDBService.Enums;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Models
{
    public class User : AMongoDBItem, IUser
    {
        private static readonly string CollectionName = "Users";
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Address> Adresses { get; set; } = new List<Address>();
        public int Status { get; set; } = (int)UserStatus.Inactive;
        public List<PaymentDetails> PaymentDetailsList { get; set; } = new List<PaymentDetails>();
        public int Coins { get; set; } = 0;
        public Cart Cart { get; set; } = new Cart();
        public Store? Store { get; set; } = null;
        public UserShadow Shadow { get; set; } = new UserShadow();

        public ReturnCode DeleteUser([FromBody] string userId)
        {
            throw new NotImplementedException();
        }

        public ReturnCode Get([FromBody] string userId, ref User user)
        {
            throw new NotImplementedException();
        }

        public ReturnCode GetAll(ref User[] users)
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnCode> InsertNewUser(User user)
        {
            if (user == null)
            {
                return ReturnCode.General_Error;
            }

            Task<MongoDBReturnCodes> res = MongoDBServiceManager<User>.Instance(ConfigurationsKeeper.Instance().GetValue(Utils.DB_name.ToString()), CollectionName).Insert(user);
            if (await res == MongoDBReturnCodes.Success)
            {
                return ReturnCode.Success;
            }
            else
            {
                return ReturnCode.General_Error;
            }
        }

        public ReturnCode UpdateUser([FromBody] User user)
        {
            throw new NotImplementedException();
        }
    }
}