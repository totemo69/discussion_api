using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using discussion_api.Entities;
using discussion_api.Dto;

namespace discussion_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DiscussionsController : ControllerBase
  {
    private readonly DataContext _context;

    public DiscussionsController(DataContext context)
    {
      _context = context;
    }

    // GET: api/Discussions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Discussion>>> GetDiscussion()
    {
      return await _context.Discussion.ToListAsync();
    }

    // GET: api/Discussions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DiscussionDto>> GetDiscussion(int id)
    {
      var discussion = await _context.Discussion.FindAsync(id);

      if (discussion == null)
      {
        return NotFound();
      }

      DiscussionDto result = new DiscussionDto
      {
        Id = discussion.Id,
        Subject = discussion.Subject,
        DiscussionDate = discussion.DiscussionDate,
        Location = discussion.Location,
        Outcome = discussion.Outcome,
        Notes = discussion.Notes
      };

      return result;
    }

    // PUT: api/Discussions/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDiscussion(int id, Discussion discussion)
    {
      if (id != discussion.Id)
      {
        return BadRequest();
      }

      _context.Entry(discussion).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DiscussionExists(id))
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

    // POST: api/Discussions
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Discussion>> PostDiscussion(Discussion discussion)
    {
      _context.Discussion.Add(discussion);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetDiscussion", new { id = discussion.Id }, discussion);
    }

    // DELETE: api/Discussions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiscussion(int id)
    {
      var discussion = await _context.Discussion.FindAsync(id);
      if (discussion == null)
      {
        return NotFound();
      }

      _context.Discussion.Remove(discussion);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool DiscussionExists(int id)
    {
      return _context.Discussion.Any(e => e.Id == id);
    }
  }
}
