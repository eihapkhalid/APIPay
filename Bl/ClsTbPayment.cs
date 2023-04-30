using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bl.IBusinessLayer;

namespace Bl
{
    public class ClsTbPayment : IBusinessLayer<TbPayment>
    {
        #region define DbContext
        PaymentUserDbContext context;
        public ClsTbPayment(PaymentUserDbContext ctx)
        {
            context = ctx;
        }

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

        public List<TbPayment> GetAll()
        {
            throw new NotImplementedException();
        }

        public TbPayment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Payments(TbPayment table)
        {
            throw new NotImplementedException();
        }

        public bool Save(TbPayment table)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
