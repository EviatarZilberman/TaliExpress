using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILogin LoginWorker;
        public LoginController(ILogin loginWorker)
        {
            this.LoginWorker = loginWorker;
        }

        [HttpGet("login")]
        [Route("login")]
        public IActionResult? Login(string email, string password)
        {
            (ReturnCode result, string user) = this.LoginWorker.Login(email, password);
            if (result == ReturnCode.Success) return Ok(user);
            return Ok(result);
        }
    }
}