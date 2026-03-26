using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface ILogin
    {
        public Task<LoginResponse> Login(string email, string password, bool stayLoggedIn, HttpContext context);
        public Task<LogoutResponse> LogOut(HttpContext httpContext);
    }
}