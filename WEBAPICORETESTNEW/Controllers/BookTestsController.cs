using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBAPICORETESTNEW.Models;

namespace WEBAPICORETESTNEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTestsController : ControllerBase
    {
        private readonly AdminTestDbContext _context;

        public BookTestsController(AdminTestDbContext context)
        {
            _context = context;
        }

        // GET: api/BookTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTestnew>>> GetBookTestnew()
        {
            return await _context.BookTestnew.ToListAsync();
        }

        // GET: api/BookTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookTestnew>> GetBookTestnew(int id)
        {
            var bookTestnew = await _context.BookTestnew.FindAsync(id);

            if (bookTestnew == null)
            {
                return NotFound();
            }

            return bookTestnew;
        }

        // PUT: api/BookTests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTestnew(int id, BookTestnew bookTestnew)
        {
            if (id != bookTestnew.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookTestnew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTestnewExists(id))
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

        // POST: api/BookTests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookTestnew>> PostBookTestnew(BookTestnew bookTestnew)
        {
            _context.BookTestnew.Add(bookTestnew);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookTestnewExists(bookTestnew.BookId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookTestnew", new { id = bookTestnew.BookId }, bookTestnew);
        }

        // DELETE: api/BookTests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookTestnew>> DeleteBookTestnew(int id)
        {
            var bookTestnew = await _context.BookTestnew.FindAsync(id);
            if (bookTestnew == null)
            {
                return NotFound();
            }

            _context.BookTestnew.Remove(bookTestnew);
            await _context.SaveChangesAsync();

            return bookTestnew;
        }

        private bool BookTestnewExists(int id)
        {
            return _context.BookTestnew.Any(e => e.BookId == id);
        }
    }
}
