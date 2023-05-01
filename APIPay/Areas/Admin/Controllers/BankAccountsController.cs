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

        #region Edit by bankAccount id
        public IActionResult Edit(int? bankAccountId)
        {
            var ObjBankAccount = new TbBankAccount();

            if (bankAccountId != null)
            {
                ObjBankAccount = oClsTbBankAccount.GetById(Convert.ToInt32(bankAccountId));
            }
            return View(ObjBankAccount);
        }
        #endregion

        #region Save by bankAccount object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbBankAccount bankAccount)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", bankAccount);
            }
            oClsTbBankAccount.Save(bankAccount);
            return RedirectToAction("List");
        }
        #endregion

    }
}
