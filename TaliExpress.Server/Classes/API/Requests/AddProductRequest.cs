using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class AddProductRequest
    {
        public ProductDbModel Product { get; set; } = new ProductDbModel();
    }
}
