using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamMemberController : ControllerBase
{
    private readonly FinalProjectContext _context;

    public TeamMemberController(FinalProjectContext context)
    {
        _context = context;
    }

    // GET: api/TeamMember/{id?}
    [HttpGet("{id?}")]
    public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.TeamMembers.Take(5).ToListAsync();
        }

        var teamMember = await _context.TeamMembers.FindAsync(id);
        if (teamMember == null) return NotFound();

        return Ok(teamMember);
    }

    // POST: api/TeamMember
    [HttpPost]
    public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
    {
        _context.TeamMembers.Add(teamMember);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTeamMembers), new { id = teamMember.Id }, teamMember);
    }

    // PUT: api/TeamMember/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeamMember(int id, TeamMember teamMember)
    {
        if (id != teamMember.Id) return BadRequest();

        _context.Entry(teamMember).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/TeamMember/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeamMember(int id)
    {
        var teamMember = await _context.TeamMembers.FindAsync(id);
        if (teamMember == null) return NotFound();

        _context.TeamMembers.Remove(teamMember);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}