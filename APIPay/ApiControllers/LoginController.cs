using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static Bl.IBusinessLayer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Security.Claims;

namespace APIPay.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    { 
        #region dependency injection region

        //Jwt:
        IConfiguration configuration;

        IBusinessLayer<TbUser> oClsUsers;
        public LoginController(IConfiguration iconfig, IBusinessLayer<TbUser> Users)
        {
            oClsUsers = Users;
            configuration = iconfig;
        }
        #endregion

        #region Login function
        // POST https://localhost:7255/api/login
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] TbUser user)
        {
            var response = Unauthorized();
            var xuser = oClsUsers.AuthorizeUser(user);
            if (xuser != null)
            {
                var newToken = GenerateToken(user);
                return Ok(new { token = newToken });//new obj has key named token with value newToken 
            }
            return response;
        }
        #endregion

        #region GenerateToken Function :
        string GenerateToken(TbUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        #endregion
    }
}
