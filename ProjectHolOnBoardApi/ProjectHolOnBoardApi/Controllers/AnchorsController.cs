using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHolOnBoardApi.Data;
using ProjectHolOnBoardApi.models;

namespace ProjectHolOnBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnchorsController : ControllerBase
    {
        private readonly ProjectHolOnBoardApiContext _context;

        public AnchorsController(ProjectHolOnBoardApiContext context)
        {
            _context = context;
        }

        // GET: api/Anchors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anchor>>> GetAnchor()
        {
            return await _context.Anchor.ToListAsync();
        }

        // GET: api/Anchors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anchor>> GetAnchor(int id)
        {
            var anchor = await _context.Anchor.FindAsync(id);

            if (anchor == null)
            {
                return NotFound();
            }

            return anchor;
        }

        // PUT: api/Anchors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnchor(int id, Anchor anchor)
        {
            if (id != anchor.id_anchor)
            {
                return BadRequest();
            }

            _context.Entry(anchor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnchorExists(id))
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

        // POST: api/Anchors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anchor>> PostAnchor(Anchor anchor)
        {
            _context.Anchor.Add(anchor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnchor", new { id = anchor.id_anchor }, anchor);
        }

        // DELETE: api/Anchors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnchor(int id)
        {
            var anchor = await _context.Anchor.FindAsync(id);
            if (anchor == null)
            {
                return NotFound();
            }

            _context.Anchor.Remove(anchor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnchorExists(int id)
        {
            return _context.Anchor.Any(e => e.id_anchor == id);
        }
    }
}
