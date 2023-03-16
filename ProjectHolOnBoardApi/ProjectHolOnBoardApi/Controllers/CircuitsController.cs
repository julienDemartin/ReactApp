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
    public class CircuitsController : ControllerBase
    {
        private readonly ProjectHolOnBoardApiContext _context;

        public CircuitsController(ProjectHolOnBoardApiContext context)
        {
            _context = context;
        }

        // GET: api/Circuits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circuit>>> GetCircuit()
        {
            var circuits = await _context.Circuit.ToListAsync();
            foreach(var circuit in circuits)
            {
               circuit.Stage = _context.Stage.Where(stage => stage.id_circuit == circuit.id_circuit)
                    .Select(x => x).ToList();
            


               
               
            }
            return circuits;
        }

        // GET: api/Circuits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Circuit>> GetCircuit(int id)
        {
            var circuit = await _context.Circuit.FindAsync(id);

            if (circuit == null)
            {
                return NotFound();
            }

            return circuit;
        }

        // PUT: api/Circuits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCircuit(int id, Circuit circuit)
        {
            if (id != circuit.id_circuit)
            {
                return BadRequest();
            }

            _context.Entry(circuit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CircuitExists(id))
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

        // POST: api/Circuits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Circuit>> PostCircuit(Circuit circuit)
        {
            _context.Circuit.Add(circuit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCircuit", new { id = circuit.id_circuit }, circuit);
        }

        // DELETE: api/Circuits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCircuit(int id)
        {
            var circuit = await _context.Circuit.FindAsync(id);
            if (circuit == null)
            {
                return NotFound();
            }

            _context.Circuit.Remove(circuit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CircuitExists(int id)
        {
            return _context.Circuit.Any(e => e.id_circuit == id);
        }
    }
}
