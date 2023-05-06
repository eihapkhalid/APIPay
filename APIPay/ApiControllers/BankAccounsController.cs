using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bl.Interfaces;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankAccounsController : ControllerBase
    {
        #region dependency injection region
        IBusinessLayer<TbBankAccount> oBankAccountService;
        public BankAccounsController(IBusinessLayer<TbBankAccount> bankAccount)
        {
            oBankAccountService = bankAccount;

        }
        #endregion

        #region GET All BankAccouns:
        [HttpGet]
        [Route("Get")]
        public List<TbBankAccount> Get()
        {
            return oBankAccountService.GetAll();
        }
        #endregion

        #region GET BankAccouns By Id:
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public TbBankAccount Get(int id)
        {
            return oBankAccountService.GetById(id);
        }
        #endregion

        #region POST New or Edit BankAccount:
        [HttpPost]
        public void Post([FromBody] TbBankAccount bankAccount)
        {
            oBankAccountService.Save(bankAccount);
        }
        #endregion

        #region POST Delte BanckAcount: 
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int banckAcountId)
        {
            oBankAccountService.Delete(banckAcountId);
        }
        #endregion
    }
}
