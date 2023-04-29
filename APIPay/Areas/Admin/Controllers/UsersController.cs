using Domains;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        #region Dependancy Injections
        IBusinessLayer<TbUser> oClsUsers;
        public UsersController(IBusinessLayer<TbUser> Users)
        {
            oClsUsers = Users;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            return View();
        } 
        #endregion

        #region List of Users
        public IActionResult List()
        {
            var lstUsers = oClsUsers.GetAll();
            return View(lstUsers);
        }
        #endregion
    }
}
