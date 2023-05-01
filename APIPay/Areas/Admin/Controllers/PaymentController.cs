using Domains;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        #region Dependancy Injections
        IBusinessLayer<TbPayment> oClsTbPayment;
        public PaymentController(IBusinessLayer<TbPayment> payment)
        {
            oClsTbPayment = payment;
        }
        #endregion

       
    }
}
