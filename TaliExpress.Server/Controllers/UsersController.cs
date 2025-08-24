using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            UsersManager usersManager = new UsersManager();
            await usersManager.Insert(user);
            //-- TODO =  Send verification email (not implemented)
            return Ok();
        }
    }
}