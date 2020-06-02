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
    public class MedicinesController : ControllerBase
    {
        private readonly PharmacyDBContext _context;

        public MedicinesController(PharmacyDBContext context)
        {
            _context = context;
        }

        // GET: api/Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicines>>> GetMedicines()
        {
            return await _context.Medicines.ToListAsync();
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicines>> GetMedicines(int id)
        {
            var medicines = await _context.Medicines.FindAsync(id);

            if (medicines == null)
            {
                return NotFound();
            }

            return medicines;
        }

        // PUT: api/Medicines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicines(int id, Medicines medicines)
        {
            if (id != medicines.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinesExists(id))
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

        // POST: api/Medicines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medicines>> PostMedicines(Medicines medicines)
        {
            _context.Medicines.Add(medicines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicines", new { id = medicines.Id }, medicines);
        }

        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medicines>> DeleteMedicines(int id)
        {
            var medicines = await _context.Medicines.FindAsync(id);
            if (medicines == null)
            {
                return NotFound();
            }

            _context.Medicines.Remove(medicines);
            await _context.SaveChangesAsync();

            return medicines;
        }

        private bool MedicinesExists(int id)
        {
            return _context.Medicines.Any(e => e.Id == id);
        }
    }
}
