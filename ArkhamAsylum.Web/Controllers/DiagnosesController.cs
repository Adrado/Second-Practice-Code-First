using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArkhamAsylum.Lib.DAL;
using ArkhamAsylum.Lib.Models;

namespace ArkhamAsylum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosesController : ControllerBase
    {
        private readonly ArkhamAsylumDbContext _context;

        public DiagnosesController(ArkhamAsylumDbContext context)
        {
            _context = context;
        }

        // GET: api/Diagnoses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diagnosis>>> GetDiagnoses()
        {
            return await _context.Diagnoses.ToListAsync();
        }

        // GET: api/Diagnoses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diagnosis>> GetDiagnosis(Guid id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);

            if (diagnosis == null)
            {
                return NotFound();
            }

            return diagnosis;
        }

        // PUT: api/Diagnoses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiagnosis(Guid id, Diagnosis diagnosis)
        {
            if (id != diagnosis.Id)
            {
                return BadRequest();
            }

            _context.Entry(diagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiagnosisExists(id))
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

        // POST: api/Diagnoses
        [HttpPost]
        public async Task<ActionResult<Diagnosis>> PostDiagnosis(Diagnosis diagnosis)
        {
            _context.Diagnoses.Add(diagnosis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiagnosis", new { id = diagnosis.Id }, diagnosis);
        }

        // DELETE: api/Diagnoses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diagnosis>> DeleteDiagnosis(Guid id)
        {
            var diagnosis = await _context.Diagnoses.FindAsync(id);
            if (diagnosis == null)
            {
                return NotFound();
            }

            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();

            return diagnosis;
        }

        private bool DiagnosisExists(Guid id)
        {
            return _context.Diagnoses.Any(e => e.Id == id);
        }
    }
}
