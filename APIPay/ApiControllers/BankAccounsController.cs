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

        #region GET BankAccouns By Id:
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public TbBankAccount Get(int id)
        {
            return oClsTbBankAccount.GetById(id);
        }
        #endregion

        #region POST New or Edit BankAccount:
        [HttpPost]
        public void Post([FromBody] TbBankAccount bankAccount)
        {
            oClsTbBankAccount.Save(bankAccount);
        }
        #endregion

        #region POST Delte BanckAcount: 
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int banckAcountId)
        {
            oClsTbBankAccount.Delete(banckAcountId);
        }
        #endregion
    }
}
