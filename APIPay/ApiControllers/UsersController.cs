using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Bl.IBusinessLayer;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        #region dependency injection region
        IBusinessLayer<TbUser> oClsUsers;
        public UsersController(IBusinessLayer<TbUser> Users)
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
        public void Delete([FromBody] int userId)
        {
            oClsUsers.Delete(userId);
        }
        #endregion

    }
}
