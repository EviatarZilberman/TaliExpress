namespace TaliExpress.Server.Classes.API.Requests
{
    public class OpenStoreRequest : BaseApiRequest
    {
        public string OwnerEmail { get; set; } = string.Empty;
        public string StoreName { get; set; } = string.Empty;
    }
}
