using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        private readonly HttpContextAccessor ContextAccessor;
        public LoginController(ILogin loginWorker, HttpContextAccessor contextAccessor)
        {
            this.LoginWorker = loginWorker;
            this.ContextAccessor = contextAccessor;
        }

        [HttpGet("login")]
        [Route("login")]
        public async Task<LoginResponse>? Login(string email, string password/*, bool stayLoggedIn = false*/)
        {
            LoginResponse loginResponse = new LoginResponse();
            (ReturnCode result, string user) = await this.LoginWorker.Login(email, password, this.ContextAccessor.HttpContext!/*, stayLoggedIn*/);
            if (result == ReturnCode.Success)
            {
                loginResponse.code = 0;
                loginResponse.message = "Successfully Login!";
                return loginResponse;
            }
            return loginResponse;
        }

        [HttpGet("logout")]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            return await this.LoginWorker.LogOut(HttpContext)
                == ReturnCode.Success
                ? RedirectToAction("Index", "Home")
                : RedirectToAction("Index", "Error");

        }
    }
}