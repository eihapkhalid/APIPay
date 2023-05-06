using Bl.Interfaces;
using Domains;

namespace Bl.Services
{
    public class UsersService : IBusinessLayer<TbUser>
    {
        #region define DbContext
        private PaymentUserDbContext context;
        private readonly IUnitOfWork unitOfWork;
        public UsersService(PaymentUserDbContext ctx, IUnitOfWork _unitOfWork)
        {
            context = ctx;
            unitOfWork = _unitOfWork;
        }
        #endregion

        #region Delete user
        public bool Delete(int id)
        {
            try
            {

                var user = GetById(id);
                user.CurrentState = 0;
                unitOfWork.Commit(); //context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        #endregion

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
                unitOfWork.Commit(); //context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region AuthorizeUser function:
        // way for test :
        public TbUser AuthorizeUser(TbUser table)
        {
            // Perform user authorization logic based on your business requirements
            // For example, query the database to verify username and password
            TbUser user = context.TbUsers.FirstOrDefault(u => u.UserName == table.UserName && u.Password == table.Password);

            if (user != null)
            {
                return new TbUser()
                {
                    UserName = user.UserName,
                    Email = user.Email
                };
            }

            return null;
        }
        #endregion

        #region Hashed
        public bool Payments(TbUser table)
        {
            throw new NotImplementedException();
        }
        public bool Delete(TbUser table)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
