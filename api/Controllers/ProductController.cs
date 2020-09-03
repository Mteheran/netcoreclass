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
            return context.Products;
        }


        [HttpGet]
        [Route("getbySql")]
        public ActionResult<IEnumerable<Product>> GetBySlq()
        {
            return Ok(context.Products.FromSqlRaw("SELECT IdProduct From Product").AsEnumerable());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
             if(!Guid.TryParse(id, out var productId)) return BadRequest();

            var productFound = context.Products.FirstOrDefault(p=> p.IdProduct == productId);

            if (productFound!= null)
                return Ok(productFound);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product value)
        {
            if(ModelState.IsValid)
            {
                context.Products.Add(value);
                await context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Product value)
        {
            if(ModelState.IsValid)
            {
                  if(!Guid.TryParse(id, out var productId)) return BadRequest();

                    var productFound = context.Products.FirstOrDefault(p=> p.IdProduct == productId);

                if (productFound!= null)
                {
                    productFound.DescriptionProduct = value.DescriptionProduct;
                    productFound.IdCategory = value.IdCategory;
                    productFound.Price = value.Price;
                    await context.SaveChangesAsync();
                    return Ok(productFound);
                }
                else
                return NotFound();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if(!Guid.TryParse(id, out var productId)) return BadRequest();

            var productFound = context.Products.FirstOrDefault(p=> p.IdProduct == productId);

            if (productFound!= null)
            {
                context.Products.Remove(productFound);
                await context.SaveChangesAsync();
                return Ok();
            }
                
            else
                return NotFound();
        }
    }
}