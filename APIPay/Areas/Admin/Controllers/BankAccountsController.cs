using Bl.Interfaces;
using Domains;
using Microsoft.AspNetCore.Mvc;

namespace APIPay.Areas.Admin.Controllers
{
    public class BankAccountsController : Controller
    {
        #region Dependancy Injections
        private IBusinessLayer<TbBankAccount> oBankAccountService;
        private readonly IUnitOfWork unitOfWork;
        public BankAccountsController(IBusinessLayer<TbBankAccount> bankAccount, IUnitOfWork _unitOfWork)
        {
            oBankAccountService = bankAccount;
            unitOfWork = _unitOfWork;
        }
        #endregion

        #region List of Bank Account
        public IActionResult List()
        {
            var lstBankAccounts = oBankAccountService.GetAll();
            unitOfWork.Dispose();
            return View(lstBankAccounts);
        }
        #endregion

        #region Edit by bankAccount id
        public IActionResult Edit(int? bankAccountId)
        {
            var ObjBankAccount = new TbBankAccount();

            if (bankAccountId != null)
            {
                ObjBankAccount = oBankAccountService.GetById(Convert.ToInt32(bankAccountId));
            }
            unitOfWork.Dispose();
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
            oBankAccountService.Save(bankAccount);
            unitOfWork.Dispose();
            return RedirectToAction("List");
        }
        #endregion

        #region Delete By bankAccount Id
        public IActionResult Delete(int bankAccountId)
        {
            oBankAccountService.Delete(bankAccountId);
            unitOfWork.Dispose();
            return RedirectToAction("List");
        }
        #endregion

    }
}