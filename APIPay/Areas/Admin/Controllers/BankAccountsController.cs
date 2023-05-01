using Microsoft.AspNetCore.Mvc;

namespace APIPay.Areas.Admin.Controllers
{
    public class BankAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
