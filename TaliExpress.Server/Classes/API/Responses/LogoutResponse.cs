using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class LogoutResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; } = -1;
    }
}