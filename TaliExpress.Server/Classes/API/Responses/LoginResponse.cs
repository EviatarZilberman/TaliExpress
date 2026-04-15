using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class LoginResponse : BaseApiResponse
    {
        public UserAng User { get; set; } = new UserAng();
        public StoreAng Store { get; set; } = new StoreAng();
        public CartAng Cart { get; set; } = new CartAng();
    }
}
