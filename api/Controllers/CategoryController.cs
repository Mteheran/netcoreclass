using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.DBContext;
using Microsoft.EntityFrameworkCore;
using shared.Models;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [EnableCors("category")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        StoreContext context;

        public CategoryController(StoreContext db)
        {
            context = db;
            context.Database.EnsureCreated();
        } 

        //[ResponseCache(Duration=60)]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return context.Categories;
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(string id)
        {
            if(!Guid.TryParse(id, out var categoryId)) return BadRequest();

            var categoryFound = context.Categories.FirstOrDefault(p=> p.IdCategory == categoryId);

            if (categoryFound!= null)
                return Ok(categoryFound);
            else
                return NotFound();
        }

    }
}