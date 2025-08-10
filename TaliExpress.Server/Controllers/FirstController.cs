using Microsoft.AspNetCore.Mvc;

namespace TaliExpress.Server.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
