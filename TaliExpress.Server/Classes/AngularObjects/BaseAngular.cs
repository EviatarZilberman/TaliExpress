using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public abstract class BaseAngular
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
