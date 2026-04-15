using System.Text.Json.Serialization;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public abstract class BaseAngOwner : BaseAngular
    {
        [JsonPropertyName("userId")]
        public string userId { get; set; } = string.Empty;
    }
}
