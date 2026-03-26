using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAngular")]
    public class LoginController : ControllerBase
    {
        private readonly ILogin LoginWorker;

        public LoginController(ILogin loginWorker)
        {
            this.LoginWorker = loginWorker;
        }

        [HttpPost("login")]
        public async Task<LoginResponse>? Login([FromBody] LoginRequest loginRequest)
        {
            return await this.LoginWorker.Login(loginRequest.Email, loginRequest.Password, loginRequest.StayLoggedIn, this.HttpContext);
        }

        [HttpGet("logout")]
        public async Task<LogoutResponse> LogOut()
        {
            return await this.LoginWorker.LogOut(HttpContext);
        }
    }
}