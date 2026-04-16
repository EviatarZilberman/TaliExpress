using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class SearchRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
