using MongoDBService.Classes;
using System.Text.Json.Serialization;

namespace TaliExpress.Server.Models
{
    public abstract class UserOwner : AMongoDBItem
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; } = string.Empty;
    }
}