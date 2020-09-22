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

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public LoginUserController(IConfiguration config)
        {
            configuration = config;
        }

        [AllowAnonymous]
        [HttpGet("RequestToken")]
        public JsonResult RequestToken()
        {
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
                    new Claim(ClaimTypes.Name, "User 1"),
                    new Claim(ClaimTypes.Role, "User")
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

            return new JsonResult(new { token });
        }
    }
}