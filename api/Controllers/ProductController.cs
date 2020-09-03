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
    public class ProductController : ControllerBase
    {
       StoreContext context;

        public ProductController(StoreContext db)
        {
            context = db;
            context.Database.EnsureCreated();
        } 

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return context.Products.Include(p=> p.Category).ThenInclude(p=> p.Products).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
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