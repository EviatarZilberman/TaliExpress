using MongoDBService.Classes;

namespace TaliExpress.Server.Models
{
    public class ProductDbModel : AMongoDBItem
    {
        public double Price { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string ImageUrl { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new List<string>();
        public int AmountInInvenotry { get; set; } = 0;
        public string SellerId { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = false;
        public double DiscountId { get; set; } = 0;
    }
}