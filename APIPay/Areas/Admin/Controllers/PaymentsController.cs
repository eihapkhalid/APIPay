using Bl;
using Domains;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentsController : Controller
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

        #region Edit Payment by id
        public IActionResult Edit(int? paymentId)
        {
            var ObjPayment = new TbPayment();

            if (paymentId != null)
            {
                ObjPayment = oClsTbPayment.GetById(Convert.ToInt32(paymentId));
            }
            return View(ObjPayment);
        }
        #endregion

        #region Save by payment object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbPayment payment)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", payment);
            }
            oClsTbPayment.Save(payment);
            return RedirectToAction("List");
        }
        #endregion

        #region Delete By payment Id
        public IActionResult Delete(int paymentId)
        {
            oClsTbPayment.Delete(paymentId);
            return RedirectToAction("List");
        }
        #endregion
    }
}
