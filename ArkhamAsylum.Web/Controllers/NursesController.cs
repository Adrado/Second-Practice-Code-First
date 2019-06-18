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
    public class NursesController : ControllerBase
    {
        private readonly ArkhamAsylumDbContext _context;

        public NursesController(ArkhamAsylumDbContext context)
        {
            _context = context;
        }

        // GET: api/Nurses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        {
            return await _context.Nurses.ToListAsync();
        }

        // GET: api/Nurses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(Guid id)
        {
            var nurse = await _context.Nurses.FindAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return nurse;
        }

        // PUT: api/Nurses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurse(Guid id, Nurse nurse)
        {
            if (id != nurse.Id)
            {
                return BadRequest();
            }

            _context.Entry(nurse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseExists(id))
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

        // POST: api/Nurses
        [HttpPost]
        public async Task<ActionResult<Nurse>> PostNurse(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNurse", new { id = nurse.Id }, nurse);
        }

        // DELETE: api/Nurses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nurse>> DeleteNurse(Guid id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }

            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();

            return nurse;
        }

        private bool NurseExists(Guid id)
        {
            return _context.Nurses.Any(e => e.Id == id);
        }
    }
}
