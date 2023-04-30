using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bl.IBusinessLayer;

namespace Bl
{
    public class ClsTbBankAccount : IBusinessLayer<TbBankAccount>
    {
        #region define DbContext
        PaymentUserDbContext context;
        public ClsTbBankAccount(PaymentUserDbContext ctx)
        {
            context = ctx;
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            try
            {

                var bankAccount = GetById(id);
                bankAccount.CurrentState = 0;
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get All Bank Accounts
        public List<TbBankAccount> GetAll()
        {
            try
            {
                var lstBankAccounts = context.TbBankAccounts.Where(a => a.CurrentState == 1).ToList();
                return lstBankAccounts;
            }
            catch
            {
                return new List<TbBankAccount>();
            }
        }
        #endregion

        #region Get BankAccount By id
        public TbBankAccount GetById(int id)
        {
            try
            {
                var ObjBankAccount = context.TbBankAccounts.Where(a => a.BankAccountId == id && a.CurrentState == 1).FirstOrDefault();
                return ObjBankAccount;
            }
            catch
            {
                return new TbBankAccount();
            }
        }
        #endregion

        #region Save
        public bool Save(TbBankAccount bankAccount)
        {
            try
            {
                if (bankAccount.BankAccountId == 0)
                {
                    bankAccount.CurrentState = 1;
                    context.TbBankAccounts.Add(bankAccount);
                }
                else
                {
                    // user.CurrentState = 1;
                    context.Entry(bankAccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        } 
        #endregion

        #region Hashed Func
        public bool Payments(TbBankAccount table)
        {
            throw new NotImplementedException();
        }

        public TbBankAccount AuthorizeUser(TbBankAccount table)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
