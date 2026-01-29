using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class LoginResponse : BaseApiResponse
    {
        public User User { get; set; } = new User();
        public Store Store { get; set; } = new Store();
        public Cart Cart { get; set; } = new Cart();
    }
}
