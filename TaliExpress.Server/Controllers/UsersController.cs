using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            UsersManager usersManager = new UsersManager();
            await usersManager.Insert(user);
            return Ok();
            //return RedirectToAction("Index");
        }
    }
}