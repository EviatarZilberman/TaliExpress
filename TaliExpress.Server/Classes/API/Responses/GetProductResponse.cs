using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class GetProductResponse
    {
        public ProductAng Product { get; set; } = new ProductAng();
    }
}