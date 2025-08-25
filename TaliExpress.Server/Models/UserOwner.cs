using MongoDBService.Classes;

namespace TaliExpress.Server.Models
{
    public abstract class UserOwner : AMongoDBItem
    {
        public string Username { get; set; } = string.Empty;
    }
}
