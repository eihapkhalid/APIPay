using Bl.Interfaces;
using Domains;
using Microsoft.AspNetCore.Mvc;

namespace APIPay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentsController : Controller
    {
        #region Dependancy Injections
        private IBusinessLayer<TbPayment> oPaymentService;
        private readonly IUnitOfWork unitOfWork;
        public PaymentsController(IBusinessLayer<TbPayment> payment, IUnitOfWork _unitOfWork)
        {
            oPaymentService = payment;
            unitOfWork = _unitOfWork;
        }
        #endregion

        #region List of Payments
        public IActionResult List()
        {
            var lstPayments = oPaymentService.GetAll();
            unitOfWork.Dispose();
            return View(lstPayments);
        }
        #endregion

        #region Edit Payment by id
        public IActionResult Edit(int? paymentId)
        {
            var ObjPayment = new TbPayment();

            if (paymentId != null)
            {
                ObjPayment = oPaymentService.GetById(Convert.ToInt32(paymentId));
            }
            unitOfWork.Dispose();
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
            oPaymentService.Save(payment);
            unitOfWork.Dispose();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete By payment Id
        public IActionResult Delete(int paymentId)
        {
            oPaymentService.Delete(paymentId);
            unitOfWork.Dispose();
            return RedirectToAction("List");
        }
        #endregion
    }
}
