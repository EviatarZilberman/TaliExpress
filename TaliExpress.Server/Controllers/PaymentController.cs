using Microsoft.AspNetCore.Mvc;

namespace TaliExpress.Server.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitPayment()
        {
            return Ok();
        }
    }
}
