namespace TaliExpress.Server.Models
{
    public class CartDbModel : UserOwner
    {
        public Dictionary<string, int> Products { get; set; } = new Dictionary<string, int>();
    }
}