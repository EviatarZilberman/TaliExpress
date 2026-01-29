using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class LoginResponse : BaseApiResponse
    {
        public User Data { get; set; } = new User();
    }
}
