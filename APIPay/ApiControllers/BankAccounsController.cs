using Bl;
using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccounsController : ControllerBase
    {
        #region dependency injection region
        IBusinessLayer<TbBankAccount> oClsTbBankAccount;
        public BankAccounsController(IBusinessLayer<TbBankAccount> bankAccount)
        {
            oClsTbBankAccount = bankAccount;

        }
        #endregion

        #region GET All BankAccouns:
        [HttpGet]
        [Route("Get")]
        public List<TbBankAccount> Get()
        {
            return oClsTbBankAccount.GetAll();
        }
        #endregion
    }
}
