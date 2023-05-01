using Domains;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.Areas.Admin.Controllers
{
    public class BankAccountsController : Controller
    {
        #region Dependancy Injections
        IBusinessLayer<TbBankAccount> oClsTbBankAccount;
        public BankAccountsController(IBusinessLayer<TbBankAccount> bankAccount)
        {
            oClsTbBankAccount = bankAccount;
        }
        #endregion
    }
}
