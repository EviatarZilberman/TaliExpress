using MongoDBService.Classes;

namespace TaliExpress.Server.Models
{
    public class UserAdresses : UserOwner
    {
        public LinkedList<Address> Addresses { get; set; } = new LinkedList<Address>();
    }
}
