using Bl;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        #region dependency injection region
        IBusinessLayer<TbPayment> oClsTbPayment;
        public PaymentsController(IBusinessLayer<TbPayment> payment)
        {
            oClsTbPayment = payment;

        }
        #endregion

        #region GET All Payments:
        [HttpGet]
        [Route("Get")]
        public List<TbPayment> Get()
        {
            return oClsTbPayment.GetAll();
        }
        #endregion
    }
}
