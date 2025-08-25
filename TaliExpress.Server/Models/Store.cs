namespace TaliExpress.Server.Models
{
    public class Store : UserOwner
    {
        LinkedList<Product> Products { get; set; } = new LinkedList<Product>();
        public string Name { get; set; } = string.Empty;
        public string[] ShipTo { get; set; } = new string[] { "All" };
    }
}