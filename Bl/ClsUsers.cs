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

        #region Get All User Data
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
        #endregion

        #region Get user By Id
        public TbUser GetById(int id)
        {
            try
            {

                var ObjUser = context.TbUsers.Where(a => a.UserId == id && a.CurrentState == 1).FirstOrDefault();
                return ObjUser;
            }
            catch
            {
                return new TbUser();
            }
        }
        #endregion

        #region Save or Edit user Data
        public bool Save(TbUser user)
        {
            try
            {
                if (user.UserId == 0)
                {
                    user.CurrentState = 1;
                    context.TbUsers.Add(user);
                }
                else
                {
                   // user.CurrentState = 1;
                    context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public bool Payments(TbUser table)
        {
            throw new NotImplementedException();
        }
    }
}
