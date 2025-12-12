using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet("login")]
        //[Route("login")]
        //public IActionResult? Login(string email, string password)
        //{
        //    //return Ok();
        //    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.No_parameters_entered));
        //    if (this.mUsersManager.Get(email, out User? user) != Enums.ReturnCode.Success) return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.No_user_found));
        //    if (user != null)
        //    {
        //        if (user.Password != password)
        //        {
        //            user.LoginTries++;
        //            this.mUsersManager.Update(user);
        //            return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.Incorrect_password));
        //        }
        //        //-- TODO- ADD COOKIES!
        //        user.LoginTries = 0;
        //        user.LastLogin = DateTime.Now;
        //        this.mUsersManager.Update(user);
        //        string jsonUser = JsonSerializer.Serialize(user);
        //        return Ok(jsonUser);
        //    }
        //    return Ok(EnumMessagesConverter.Convert(Enums.ReturnCode.No_user_found));

        //}
    }
}
