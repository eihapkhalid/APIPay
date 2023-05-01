using Bl;
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

        #region List of Bank Account
        public IActionResult List()
        {
            var lstBankAccounts = oClsTbBankAccount.GetAll();
            return View(lstBankAccounts);
        }
        #endregion
    }
}
