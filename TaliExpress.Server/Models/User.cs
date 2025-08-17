using Microsoft.AspNetCore.Mvc;
using MongoDBService.Classes;
using TaliExpress.Server.Controllers.Interfaces;
using TaliExpress.Server.Enums;

namespace TaliExpress.Server.Models
{
    public class User : AMongoDBItem, IUser
    {
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

        public ReturnCode InsertNewUser([FromBody] User user)
        {
            throw new NotImplementedException();
        }

        public ReturnCode UpdateUser([FromBody] User user)
        {
            throw new NotImplementedException();
        }
    }
}