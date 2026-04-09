namespace TaliExpress.Server.Models
{
    public class StoreDbModel : UserOwner
    {
        public List<ProductDbModel> Products { get; set; } = new List<ProductDbModel>();
        public string StoreName { get; set; } = string.Empty;
        public string[] ShipTo { get; set; } = new string[] { "All" };
    }
}