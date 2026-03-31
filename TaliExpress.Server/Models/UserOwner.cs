using MongoDBService.Classes;

namespace TaliExpress.Server.Models
{
    public abstract class UserOwner : AMongoDBItem
    {
        public string UserId { get; set; } = string.Empty;
    }
}