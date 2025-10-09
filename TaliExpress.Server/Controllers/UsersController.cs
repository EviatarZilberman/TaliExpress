using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TaliExpress.Server.Classes;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UsersManager mUsersManager { get; set; } = new UsersManager();

        [HttpPost("register")]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            await this.mUsersManager.Insert(user);
            //-- TODO =  Send verification email (not implemented)
            return Ok();
        }

        [HttpGet("login")]
        [Route("login")]
        public IActionResult? Login(string email, string password)
        {
            //return Ok();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.No_parameters_entered));
            if (this.mUsersManager.Get(email, out User? user) != Enums.ReturnCode.Success) return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.No_user_found));
            if (user != null)
            {
                if (user.Password != password)
                {
                    user.LoginTries++;
                    this.mUsersManager.Update(user);
                    return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.Incorrect_password));
                }
                //-- TODO- ADD COOKIES!
                user.LoginTries = 0;
                user.LastLogin = DateTime.Now;
                this.mUsersManager.Update(user);
                string jsonUser = JsonSerializer.Serialize(user);
                return Ok(jsonUser);
            }
            return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.No_user_found));

        }
    }
}