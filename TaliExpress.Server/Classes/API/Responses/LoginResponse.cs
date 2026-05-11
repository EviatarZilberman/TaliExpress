using TaliExpress.Server.Classes.AngularObjects;

namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class LoginResponse : BaseApiResponse
    {
        public UserAng User { get; set; } = new UserAng();
        public StoreDataAng StoreData { get; set; } = new StoreDataAng();
        public CartDataAng CartData { get; set; } = new CartDataAng();
    }
}
