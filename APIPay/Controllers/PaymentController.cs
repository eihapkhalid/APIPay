using Microsoft.AspNetCore.Mvc;

namespace APIPay.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
