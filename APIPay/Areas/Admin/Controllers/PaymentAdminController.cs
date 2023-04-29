using Microsoft.AspNetCore.Mvc;

namespace APIPay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
