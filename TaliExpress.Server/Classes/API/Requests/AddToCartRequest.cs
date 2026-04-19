namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class AddToCartRequest
    {
        public string productId { get; set; } = string.Empty;
        public int Amount { get; set; } = 1;
    }
}
