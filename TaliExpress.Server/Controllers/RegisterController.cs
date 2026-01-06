using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.Common;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegister RegistrationWorker;
        public RegisterController (IRegister registrationWorker)
        {
            this.RegistrationWorker = registrationWorker;
        }
        

        [HttpPost("register")]
        //[Route("register")]
        public IActionResult Register([FromBody] RegistrationUser user)
        {
            this.RegistrationWorker.Register(user);
            return RedirectToAction("Index", "First");
        }
    }
}