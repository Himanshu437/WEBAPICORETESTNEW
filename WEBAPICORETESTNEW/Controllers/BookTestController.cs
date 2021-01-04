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
    public class BookTestController : ControllerBase
    {
        private readonly AdminTestDbContext _context;

        public BookTestController(AdminTestDbContext context)
        {
            _context = context;
        }

        // GET: api/BookTest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookTest>>> GetBookTest()
        {
            return await _context.BookTest.ToListAsync();
        }

        // GET: api/BookTest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookTest>> GetBookTest(int id)
        {
            var bookTest = await _context.BookTest.FindAsync(id);

            if (bookTest == null)
            {
                return NotFound();
            }

            return bookTest;
        }

        // PUT: api/BookTest/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookTest(int id, BookTest bookTest)
        {
            if (id != bookTest.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookTestExists(id))
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

        // POST: api/BookTest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookTest>> PostBookTest(BookTest bookTest)
        {
            _context.BookTest.Add(bookTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookTest", new { id = bookTest.BookId }, bookTest);
        }

        // DELETE: api/BookTest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookTest>> DeleteBookTest(int id)
        {
            var bookTest = await _context.BookTest.FindAsync(id);
            if (bookTest == null)
            {
                return NotFound();
            }

            _context.BookTest.Remove(bookTest);
            await _context.SaveChangesAsync();

            return bookTest;
        }

        private bool BookTestExists(int id)
        {
            return _context.BookTest.Any(e => e.BookId == id);
        }
    }
}
