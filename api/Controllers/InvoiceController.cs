using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.DBContext;
using shared.Models;

//using api.Models;


namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        StoreContext context;

       
        public InvoiceController(StoreContext db)
        {
            context = db;
            context.Database.EnsureCreated();
        }

        // GET api/invoice
        [HttpGet("")]
        public ActionResult<IEnumerable<Invoice>> Get()
        {
            return context.Invoices;
        }

        // GET api/invoice/5
        [HttpGet("{id}")]
        public ActionResult<Invoice> GetInvoiceById(string id)
        {
            if(!Guid.TryParse(id, out var invoiceId)) return BadRequest();

            var invoiceFound = context.Invoices.FirstOrDefault(p=> p.IdInvoice == invoiceId);

            if (invoiceFound!= null)
                return Ok(invoiceFound);
            else
                return NotFound();
        }

        // POST api/invoice
        [HttpPost("")]
        public async Task<ActionResult> Poststring([FromBody] Invoice value)
        {
            if(ModelState.IsValid)
            {
                context.Invoices.Add(value);
                await context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/invoice/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Putstring(string id, [FromBody] Invoice value)
        {
            if(ModelState.IsValid)
            {
                  if(!Guid.TryParse(id, out var invoiceId)) return BadRequest();

                    var invoiceFound = context.Invoices.FirstOrDefault(p=> p.IdInvoice == invoiceId);

                if (invoiceFound!= null)
                {
                    invoiceFound.CreateTime = value.CreateTime;
                    await context.SaveChangesAsync();
                    return Ok(invoiceFound);
                }
                else
                return NotFound();
            }

            return BadRequest();
        }

        // DELETE api/invoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoiceById(string id)
        {
            if(!Guid.TryParse(id, out var invoiceId)) return BadRequest();

            var invoiceFound = context.Invoices.FirstOrDefault(p=> p.IdInvoice == invoiceId);

            if (invoiceFound!= null)
            {
                context.Invoices.Remove(invoiceFound);
                await context.SaveChangesAsync();
                return Ok();
            }
                
            else
                return NotFound();
        }
    }
}