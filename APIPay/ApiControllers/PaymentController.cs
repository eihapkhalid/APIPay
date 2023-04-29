using Microsoft.AspNetCore.Mvc;

namespace APIPay.ApiControllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
