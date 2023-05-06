using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bl.Interfaces;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        #region dependency injection region
        IBusinessLayer<TbPayment> oPaymentService;
        public PaymentsController(IBusinessLayer<TbPayment> payment)
        {
            oPaymentService = payment;

        }
        #endregion

        #region GET All Payments:
        [HttpGet]
        [Route("Get")]
        public List<TbPayment> Get()
        {
            return oPaymentService.GetAll();
        }
        #endregion

        #region GET Payment By Id:
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public TbPayment Get(int id)
        {
            return oPaymentService.GetById(id);
        }
        #endregion

        #region POST New or Edit Payment:
        [HttpPost]
        public void Post([FromBody] TbPayment payment)
        {
            oPaymentService.Save(payment);
        }
        #endregion

        #region POST Delte Payment: 
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int paymentId)
        {
            oPaymentService.Delete(paymentId);
        }
        #endregion
    }
}
