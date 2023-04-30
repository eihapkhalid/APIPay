using Bl;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        #region GET Payment By Id:
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public TbPayment Get(int id)
        {
            return oClsTbPayment.GetById(id);
        }
        #endregion

        #region POST New or Edit Payment:
        [HttpPost]
        public void Post([FromBody] TbPayment payment)
        {
            oClsTbPayment.Save(payment);
        }
        #endregion

        #region POST Delte Payment: 
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int paymentId)
        {
            oClsTbPayment.Delete(paymentId);
        }
        #endregion
    }
}
