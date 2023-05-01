using Domains;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymenstController : Controller
    {
        #region Dependancy Injections
        IBusinessLayer<TbPayment> oClsTbPayment;
        public PaymenstController(IBusinessLayer<TbPayment> payment)
        {
            oClsTbPayment = payment;
        }
        #endregion

        #region List of Payments
        public IActionResult List()
        {
            var lstPayments = oClsTbPayment.GetAll();
            return View(lstPayments);
        }
        #endregion
    }
}
