using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly FinalProjectContext _context;

    public BookController(FinalProjectContext context)
    {
        _context = context;
    }

    // GET: api/Book/{id?}
    [HttpGet("{id?}")]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.Books.Take(5).ToListAsync();
        }

        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        return Ok(book);
    }

    // POST: api/Book
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }

    // PUT: api/Book/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();

        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Book/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}