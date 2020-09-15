using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shared.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        StoreContext context;

        public UserTypeController(StoreContext db)
        {
            context = db;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserType>> Get()
        {
            return context.UserTypes;
        }


        [HttpGet]
        [Route("getbySql")]
        public ActionResult<IEnumerable<UserType>> GetBySlq()
        {
            return Ok(context.UserTypes.FromSqlRaw("SELECT IdUser_Type From UserType").AsEnumerable());
        }

        [HttpGet("{id}")]
        public ActionResult<UserType> Get(string id)
        {
            if (!Guid.TryParse(id, out var usertypeId)) return BadRequest();

            var usertypeFound = context.UserTypes.FirstOrDefault(p => p.IdUser_Type == usertypeId);

            if (usertypeFound != null)
                return usertypeFound;
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserType value)
        {
            if (ModelState.IsValid)
            {
                context.UserTypes.Add(value);
                await context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UserType value)
        {
            if (ModelState.IsValid)
            {
                if (!Guid.TryParse(id, out var usertypeId)) return BadRequest();

                var usertypeFound = context.UserTypes.FirstOrDefault(p => p.IdUser_Type == usertypeId);

                if (usertypeFound != null)
                {
                    usertypeFound.Description_Type = value.Description_Type;
          
                    await context.SaveChangesAsync();
                    return Ok(usertypeFound);
                }
                else
                    return NotFound();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out var usertypeId)) return BadRequest();

            var usertypeFound = context.UserTypes.FirstOrDefault(p => p.IdUser_Type == usertypeId);

            if (usertypeFound != null)
            {
                context.UserTypes.Remove(usertypeFound);
                await context.SaveChangesAsync();
                return Ok();
            }

            else
                return NotFound();
        }
    }
}