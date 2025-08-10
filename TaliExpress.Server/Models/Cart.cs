using MongoDB.Bson;

namespace TaliExpress.Server.Models
{
    public class Cart
    {
        public Dictionary<ObjectId, int> Products { get; set; } = new Dictionary<ObjectId, int>();
    }
}