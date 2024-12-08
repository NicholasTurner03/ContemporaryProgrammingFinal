using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[ApiController]
[Route("[controller]")]
public class HobbyController : ControllerBase
{
    private readonly FinalProjectContext _context;

    public HobbyController(FinalProjectContext context)
    {
        _context = context;
    }

    // GET: api/Hobby/{id?}
    [HttpGet("{id?}")]
    public async Task<ActionResult<IEnumerable<Hobby>>> GetHobbies(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.Hobbies.Take(5).ToListAsync();
        }

        var hobby = await _context.Hobbies.FindAsync(id);
        if (hobby == null) return NotFound();

        return Ok(hobby);
    }

    // POST: api/Hobby
    [HttpPost]
    public async Task<ActionResult<Hobby>> PostHobby(Hobby hobby)
    {
        _context.Hobbies.Add(hobby);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetHobbies), new { id = hobby.Id }, hobby);
    }

    // PUT: api/Hobby/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHobby(int id, Hobby hobby)
    {
        if (id != hobby.Id) return BadRequest();

        _context.Entry(hobby).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Hobby/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHobby(int id)
    {
        var hobby = await _context.Hobbies.FindAsync(id);
        if (hobby == null) return NotFound();

        _context.Hobbies.Remove(hobby);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}