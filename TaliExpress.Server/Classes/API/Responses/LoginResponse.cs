using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class LoginResponse : BaseApiResponse
    {
        public UserDbModel User { get; set; } = new UserDbModel();
        public StoreDbModel Store { get; set; } = new StoreDbModel();
        public Cart Cart { get; set; } = new Cart();
    }
}
