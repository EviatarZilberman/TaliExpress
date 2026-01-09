using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class LoginRequest : BaseApiRequest<User>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
