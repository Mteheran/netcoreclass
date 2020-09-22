using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using shared.Models;
using api.DBContext;
using System.Linq;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly IConfiguration configuration;

        private readonly StoreContext context;
        public LoginUserController(IConfiguration config, StoreContext db)
        {
            configuration = config;
            context = db;
        }

        [AllowAnonymous]
        [HttpGet("RequestToken")]
        public ActionResult<JsonResult> RequestToken(User userLogin)
        {

            var userfound = context.Users.FirstOrDefault(p=> p.Username == userLogin.Username);
            
            if(userfound == null)
                return NotFound();
            if(!userfound.Password.Equals(userfound.Password))
                return Unauthorized();
            var userType = context.UserTypes.FirstOrDefault(p=> p.IdUser_Type == userfound.IdUser_Type);
            DateTime utcNow = DateTime.UtcNow;

            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            //};

            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, userfound.Username),
                    new Claim(ClaimTypes.Role, userType.Description_Type)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            DateTime expiredDateTime = utcNow.AddDays(1);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Key + credentials
           
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            //string token = jwtSecurityTokenHandler.WriteToken(new JwtSecurityToken(claims: claims, expires: expiredDateTime,notBefore:utcNow,  signingCredentials: signingCredentials));
            var securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            string token  = jwtSecurityTokenHandler.WriteToken(securityToken);

            return Ok(new JsonResult(new { token }));
        }
    }
}