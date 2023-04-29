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

        #region GET All Users: api/<TransController>/Get
        [HttpGet]
        [Route("Get")]
        public List<TbUser> Get()
        {
            return oClsUsers.GetAll();
        }
        #endregion

        #region GET User By Id: api/<TransController>/Get/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public TbUser Get(int id)
        {
            return oClsUsers.GetById(id);
        }
        #endregion

        #region POST New or Edit user: api/<TransController>
        [HttpPost]
        public void Post([FromBody] TbUser user)
        {
            oClsUsers.Save(user);
        }
        #endregion

        #region POST Delte user: api/<TransController>/Delete
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] TbUser user)
        {
            oClsUsers.Delete(user);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
