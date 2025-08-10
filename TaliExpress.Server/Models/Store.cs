namespace TaliExpress.Server.Models
{
    public class Store
    {
        List<Product> Products { get; set; } = new List<Product>();
        public string Name { get; set; } = string.Empty;
    }
}