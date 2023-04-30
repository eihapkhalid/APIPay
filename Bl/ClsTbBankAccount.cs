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

        #region Delete
        public bool Delete(int id)
        {
            try
            {

                var user = GetById(id);
                user.CurrentState = 0;
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        } 
        #endregion

        public List<TbBankAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public TbBankAccount GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Payments(TbBankAccount table)
        {
            throw new NotImplementedException();
        }

        public bool Save(TbBankAccount table)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
