using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly PharmacyDBContext _context;

        public BranchesController(PharmacyDBContext context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branches>>> GetBranches()
        {
            return await _context.Branches.ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branches>> GetBranches(int id)
        {
            var branches = await _context.Branches.FindAsync(id);

            if (branches == null)
            {
                return NotFound();
            }

            return branches;
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranches(int id, Branches branches)
        {
            if (id != branches.Id)
            {
                return BadRequest();
            }

            _context.Entry(branches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchesExists(id))
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

        // POST: api/Branches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Branches>> PostBranches(Branches branches)
        {
            _context.Branches.Add(branches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranches", new { id = branches.Id }, branches);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Branches>> DeleteBranches(int id)
        {
            var branches = await _context.Branches.FindAsync(id);
            if (branches == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branches);
            await _context.SaveChangesAsync();

            return branches;
        }

        private bool BranchesExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }
    }
}
