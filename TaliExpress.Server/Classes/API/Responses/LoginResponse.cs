using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class LoginResponse : BaseApiResponse<User>
    {
        public int code { get; set; } = -1;
        public string message { get; set; } = string.Empty;
    }
}
