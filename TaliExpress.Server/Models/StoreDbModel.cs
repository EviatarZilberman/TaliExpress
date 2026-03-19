namespace TaliExpress.Server.Models
{
    public class StoreDbModel : UserOwner
    {
        LinkedList<ProductDbModel> Products { get; set; } = new LinkedList<ProductDbModel>();
        public string Name { get; set; } = string.Empty;
        public string[] ShipTo { get; set; } = new string[] { "All" };
    }
}