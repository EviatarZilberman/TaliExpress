using MongoDBService.Classes;

namespace TaliExpress.Server.Models
{
    public abstract class PrimaryState : AMongoDBItem
    {
        public bool IsPrimary { get; set; } = false;
        public void SetPrimary()
        {
            IsPrimary = true;
        }
    }
}