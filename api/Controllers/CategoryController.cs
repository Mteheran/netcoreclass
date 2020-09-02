using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.DBContext;
using shared.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        StoreContext context;

        public CategoryController(StoreContext db)
        {
            context = db;
        } 

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return context.Categories;
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(string id)
        {
            return context.Categories.FirstOrDefault(p=> p.IdCategory == Guid.Parse(id));
        }

        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            var category = new Category();
            category.Description_Category = value;
            context.Categories.Add(category);
            await context.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}