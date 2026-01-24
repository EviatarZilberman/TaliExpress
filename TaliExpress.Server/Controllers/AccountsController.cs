using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccount AccountWorker;

        public AccountsController(IAccount AccountWorker)
        {
            this.AccountWorker = AccountWorker;
        }

        [HttpPost("updateAccount")]
        public PersonalAreaUpdateResponse UpdateAccount([FromBody] PersonalAreaUpdateRequest request) => this.AccountWorker.UpdateAccount(request);
    }
}