using Domains;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.ApiControllers
{
    public class UsersController : Controller
    {
        #region dependency injection region
        IBusinessLayer<TbUser> oClsUsers;
        public UsersController(IBusinessLayer<TbUser> Users, IBusinessLayer<TbFinancialTransaction> financialTransaction, IBusinessLayer<VwTransWacountDetail> vwTransWacountDetails)
        {
            oClsUsers = Users;
            
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
