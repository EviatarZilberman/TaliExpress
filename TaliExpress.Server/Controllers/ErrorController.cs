using Microsoft.AspNetCore.Mvc;

namespace TaliExpress.Server.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
