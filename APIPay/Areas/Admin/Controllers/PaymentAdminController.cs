using Microsoft.AspNetCore.Mvc;

namespace APIPay.Areas.Admin.Controllers
{
    public class PaymentAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
