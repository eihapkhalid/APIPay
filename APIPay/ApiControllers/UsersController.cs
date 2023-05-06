using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bl.Interfaces;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        #region dependency injection region
        IBusinessLayer<TbUser> oUsersService;
        public UsersController(IBusinessLayer<TbUser> Users)
        {
            oUsersService = Users;

        }
        #endregion

        #region GET All Users: api/<TransController>/Get
        [HttpGet]
        [Route("Get")]
        public List<TbUser> Get()
        {
            return oUsersService.GetAll();
        }
        #endregion

        #region GET User By Id: api/<TransController>/Get/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public TbUser Get(int id)
        {
            return oUsersService.GetById(id);
        }
        #endregion

        #region POST New or Edit user: api/<TransController>
        [HttpPost]
        public void Post([FromBody] TbUser user)
        {
            oUsersService.Save(user);
        }
        #endregion

        #region POST Delte user: api/<TransController>/Delete
        [HttpPost]
        [Route("Delete")]
        public void Delete([FromBody] int userId)
        {
            oUsersService.Delete(userId);
        }
        #endregion

    }
}
