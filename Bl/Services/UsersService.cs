using Bl.Interfaces;
using Domains;

namespace Bl.Services
{
    public class UsersService : IBusinessLayer<TbUser>
    {
        #region define DbContext
        private readonly IGenericRepository<TbUser> userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UsersService(IGenericRepository<TbUser> _userRepository, IUnitOfWork _unitOfWork)
        {
            userRepository = _userRepository;
            unitOfWork = _unitOfWork;
        }
        #endregion

        #region Delete user
        public bool Delete(int id)
        {
            try
            {
                var user = userRepository.Get_All().SingleOrDefault(a => a.UserId == id && a.CurrentState == 1);
                if (user == null)
                {
                    return false;
                }
                user.CurrentState = 0;
                userRepository.Edit(user);
                unitOfWork.Commit(); //userRepository.SaveChanges();
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
                var lstUsers = userRepository.Get_All().Where(a => a.CurrentState == 1).ToList();
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
                var ObjUser = userRepository.FindBy(a => a.UserId == id && a.CurrentState == 1).FirstOrDefault();
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
                    userRepository.Add(user);
                }
                else
                {
                    userRepository.Edit(user);
                }
                unitOfWork.Commit();
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
            TbUser user = userRepository.FindBy(u => u.UserName == table.UserName && u.Password == table.Password).FirstOrDefault();

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
