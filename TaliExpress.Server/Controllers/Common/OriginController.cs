using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TaliExpress.Server.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAngular")]
    public class OriginController : ControllerBase
    {
    }
}
