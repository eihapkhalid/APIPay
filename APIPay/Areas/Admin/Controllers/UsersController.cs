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

        #region Edit by User id
        public IActionResult Edit(int? userId)
        {
            var ObjUser = new TbUser();

            if (userId != null)
            {
                ObjUser = oClsUsers.GetById(Convert.ToInt32(userId));
            }
            return View(ObjUser);
        }
        #endregion

        #region Save by User object
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(TbUser user)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }
            oClsUsers.Save(user);
            return RedirectToAction("List");
        }
        #endregion

        #region Delete By User Id
        public IActionResult Delete(int userId)
        {
            oClsUsers.Delete(userId);
            return RedirectToAction("List");
        }
        #endregion
    }
}
