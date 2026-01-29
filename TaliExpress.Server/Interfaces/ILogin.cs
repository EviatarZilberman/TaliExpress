using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Interfaces
{
    public interface ILogin
    {
        public Task<LoginResponse> Login(string email, string password, HttpContext context, bool stayLoggedIn = false);
        public Task<ReturnCode> LogOut(HttpContext httpContext);
    }
}
