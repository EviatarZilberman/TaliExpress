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
        public int Status { get; set; } = (int)UserStatus.Inactive;
        public int LoginTries { get; set; } = 0;
        public DateTime LastLogin { get; set; } = DateTime.MinValue;
    }
}