using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.DBContext;
using Microsoft.EntityFrameworkCore;
using shared.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using api.Tools;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        StoreContext context;

        public UserController(StoreContext db)
        {
            context = db;
            context.Database.EnsureCreated();
        } 

        [HttpGet]
        public IQueryable<User> Get()
        {
            return context.Users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            if(!Guid.TryParse(id, out var userId)) return BadRequest();

            var userFound = context.Users.FirstOrDefault(p=> p.IdUser == userId);

            if (userFound!= null)
                return Ok(userFound);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User value)
        {
            if(ModelState.IsValid)
            {
                value.Password = EncryptData.EncryptText(value.Password);
                context.Users.Add(value);
                await context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] User value)
        {
            if(ModelState.IsValid)
            {
                  if(!Guid.TryParse(id, out var userId)) return BadRequest();

                    var userFound = context.Users.FirstOrDefault(p=> p.IdUser == userId);

                if (userFound!= null)
                {
                    userFound.Username = value.Username;
                    userFound.Password = EncryptData.EncryptText(value.Password);
                    userFound.Email = value.Email;
                    userFound.IdUser_Type = value.IdUser_Type;
                    await context.SaveChangesAsync();
                    return Ok(userFound);
                }
                else
                return NotFound();
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if(!Guid.TryParse(id, out var userId)) return BadRequest();

            var userFound = context.Users.FirstOrDefault(p=> p.IdUser == userId);

            if (userFound!= null)
            {
                context.Users.Remove(userFound);
                await context.SaveChangesAsync();
                return Ok();
            }
                
            else
                return NotFound();
        }

        [HttpGet]
        [Route("byview")]
        public ActionResult<IEnumerable<UserUserType>> GetByView()
        {
            return context.UserUserTypes;
        }

        [HttpGet]
        [Route("byidbysp/{id}")]
        public ActionResult<IEnumerable<UserUserType>> GetByIdBySP(string id)
        {
            
             //return Ok(context.UserUserTypes.FromSqlRaw("SP_SelectUserUserTypeById @Id={0}",id).AsEnumerable());
             return Ok(context.UserUserTypes.FromSqlInterpolated($"SP_SelectUserUserTypeById @Id={id}").AsEnumerable());
        }

    }
}