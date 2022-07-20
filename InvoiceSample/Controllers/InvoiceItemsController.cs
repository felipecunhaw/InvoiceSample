using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceSample.Entities;

namespace InvoiceSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoiceItemsController(InvoiceContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceItems>>> GetInvoiceItems()
        {
          if (_context.InvoiceItems == null)
          {
              return NotFound();
          }
            return await _context.InvoiceItems.ToListAsync();
        }

        // GET: api/InvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItems>> GetInvoiceItems(int id)
        {
          if (_context.InvoiceItems == null)
          {
              return NotFound();
          }
            var invoiceItems = await _context.InvoiceItems.FindAsync(id);

            if (invoiceItems == null)
            {
                return NotFound();
            }

            return invoiceItems;
        }

        // PUT: api/InvoiceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceItems(int id, InvoiceItems invoiceItems)
        {
            if (id != invoiceItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InvoiceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceItems>> PostInvoiceItems(InvoiceItems invoiceItems)
        {
          if (_context.InvoiceItems == null)
          {
              return Problem("Entity set 'InvoiceContext.InvoiceItems'  is null.");
          }
            _context.InvoiceItems.Add(invoiceItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceItems", new { id = invoiceItems.Id }, invoiceItems);
        }

        // DELETE: api/InvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceItems(int id)
        {
            if (_context.InvoiceItems == null)
            {
                return NotFound();
            }
            var invoiceItems = await _context.InvoiceItems.FindAsync(id);
            if (invoiceItems == null)
            {
                return NotFound();
            }

            _context.InvoiceItems.Remove(invoiceItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceItemsExists(int id)
        {
            return (_context.InvoiceItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
