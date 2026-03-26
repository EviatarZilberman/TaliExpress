using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class LoginRequest : BaseApiRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("stayLoggedIn")]
        public bool StayLoggedIn { get; set; } = true;
    }
}