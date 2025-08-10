using MongoDBService.Classes;
using TaliExpress.Server.Enums;

namespace TaliExpress.Server.Models
{
    public class User : AMongoDBItem
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
    }
}
