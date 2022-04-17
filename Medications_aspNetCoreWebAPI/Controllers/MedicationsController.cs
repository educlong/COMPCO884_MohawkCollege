using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medications_aspNetCoreWebAPI.Models;

namespace Medications_aspNetCoreWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly CHDBContext _context;

        public MedicationsController(CHDBContext context)
        {
            _context = context;
        }

        // GET: api/Medications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
        {
            return await _context.Medications.ToListAsync();
        }

        // GET: api/Medications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
            var medication = await _context.Medications.FindAsync(id);

            if (medication == null)
            {
                return NotFound();
            }

            return medication;
        }

        // PUT: api/Medications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedication(int id, Medication medication)
        {
            if (id != medication.MedicationId)
            {
                return BadRequest();
            }

            _context.Entry(medication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicationExists(id))
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

        // POST: api/Medications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medication>> PostMedication(Medication medication)
        {
            _context.Medications.Add(medication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicationExists(medication.MedicationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedication", new { id = medication.MedicationId }, medication);
        }

        // DELETE: api/Medications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            if (medication == null)
            {
                return NotFound();
            }

            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicationExists(int id)
        {
            return _context.Medications.Any(e => e.MedicationId == id);
        }
    }
}
