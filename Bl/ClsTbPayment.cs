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

                var payment = GetById(id);
                payment.CurrentState = 0;
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get All Payments
        public List<TbPayment> GetAll()
        {
            try
            {
                var lstPayments = context.TbPayments.Where(a => a.CurrentState == 1).ToList();
                return lstPayments;
            }
            catch
            {
                return new List<TbPayment>();
            }
        } 
        #endregion

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
