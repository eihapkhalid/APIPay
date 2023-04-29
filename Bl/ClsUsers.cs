using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bl.IBusinessLayer;

namespace Bl
{
    public class ClsUsers : IBusinessLayer<TbUser>
    {
        #region define DbContext
        PaymentUserDbContext context;
        public ClsUsers(PaymentUserDbContext ctx)
        {
            context = ctx;
        } 
        #endregion

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TbUser table)
        {
            throw new NotImplementedException();
        }

        public List<TbUser> GetAll()
        {
            try
            {
                var lstUsers = context.TbUsers.Where(a => a.CurrentState == 1).ToList();
                return lstUsers;
            }
            catch
            {
                return new List<TbUser>();
            }
        }

        public TbUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Payments(TbUser table)
        {
            throw new NotImplementedException();
        }

        public bool Save(TbUser table)
        {
            throw new NotImplementedException();
        }
    }
}
