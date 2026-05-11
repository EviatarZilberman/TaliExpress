using System.Text.Json.Serialization;
using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class GetDisplayCartResponse : BaseApiResponse
    {
        [JsonPropertyName("cart")]
        public CartAng DisplayProducts { get; set; } = new CartAng();
    }
}