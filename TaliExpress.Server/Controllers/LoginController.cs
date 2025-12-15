using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILogin LoginWorker;
        private readonly HttpContextAccessor HttpContextAccessor;
        public LoginController(ILogin loginWorker, HttpContextAccessor httpContextAccessor)
        {
            this.LoginWorker = loginWorker;
            this.HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet("login")]
        [Route("login")]
        public async Task<IActionResult>? Login(string email, string password, bool stayLoggedIn = false)
        {

            (ReturnCode result, string user) = await this.LoginWorker.Login(email, password,this.HttpContextAccessor.HttpContext!, stayLoggedIn);
            if (result == ReturnCode.Success)
            {

                return Ok(user);
            }
            return Ok(result);
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