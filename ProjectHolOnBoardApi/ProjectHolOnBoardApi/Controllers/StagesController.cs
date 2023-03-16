using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectHolOnBoardApi.Data;
using ProjectHolOnBoardApi.models;

namespace ProjectHolOnBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly ProjectHolOnBoardApiContext _context;

        public StagesController(ProjectHolOnBoardApiContext context)
        {
            _context = context;
        }

        // GET: api/Stages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stage>>> GetStage()
        {


            var stages = await _context.Stage.ToListAsync();
            foreach (var stage in stages)
            {
                stage.Anchor = _context.Anchor.Where(anchor => anchor.id_anchor == stage.id_Anchor)
                    .Select(x => x).SingleOrDefault();
            }
            return stages;
        }

        // GET: api/Stages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stage>> GetStage(int id)
        {
            var stage = await _context.Stage.FindAsync(id);

            if (stage == null)
            {
                return NotFound();
            }

            return stage;
        }

        // PUT: api/Stages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStage(int id, Stage stage)
        {
            if (id != stage.id_stage)
            {
                return BadRequest();
            }

            _context.Entry(stage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StageExists(id))
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

        // POST: api/Stages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stage>> PostStage(Stage stage)
        {
            _context.Stage.Add(stage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStage", new { id = stage.id_stage }, stage);
        }

        // DELETE: api/Stages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStage(int id)
        {
            var stage = await _context.Stage.FindAsync(id);
            if (stage == null)
            {
                return NotFound();
            }

            _context.Stage.Remove(stage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StageExists(int id)
        {
            return _context.Stage.Any(e => e.id_stage == id);
        }
    }
}
