using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStore StoreWorker;

        public StoreController(IStore storeWorker)
        {
            StoreWorker = storeWorker;
        }

        [HttpPost("openStore")]
        public OpenStoreResponse OpenStore(OpenStoreRequest request)
        {
            return StoreWorker.OpenStore(request);
        }

        [HttpGet("getStore")]
        public GetStoreResponse GetStore()
        {
            return StoreWorker.GetStore(this.HttpContext);
        }
    }
}