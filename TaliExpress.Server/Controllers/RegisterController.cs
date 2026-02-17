using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
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
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            return await this.RegistrationWorker.Register(request);
        }
    }
}