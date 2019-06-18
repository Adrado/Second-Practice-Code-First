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
    public class NurseRoomAssignationsController : ControllerBase
    {
        private readonly ArkhamAsylumDbContext _context;

        public NurseRoomAssignationsController(ArkhamAsylumDbContext context)
        {
            _context = context;
        }

        // GET: api/NurseRoomAssignations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseRoomAssignation>>> GetNurseRoomAssignations()
        {
            return await _context.NurseRoomAssignations.ToListAsync();
        }

        // GET: api/NurseRoomAssignations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NurseRoomAssignation>> GetNurseRoomAssignation(Guid id)
        {
            var nurseRoomAssignation = await _context.NurseRoomAssignations.FindAsync(id);

            if (nurseRoomAssignation == null)
            {
                return NotFound();
            }

            return nurseRoomAssignation;
        }

        // PUT: api/NurseRoomAssignations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurseRoomAssignation(Guid id, NurseRoomAssignation nurseRoomAssignation)
        {
            if (id != nurseRoomAssignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(nurseRoomAssignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseRoomAssignationExists(id))
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

        // POST: api/NurseRoomAssignations
        [HttpPost]
        public async Task<ActionResult<NurseRoomAssignation>> PostNurseRoomAssignation(NurseRoomAssignation nurseRoomAssignation)
        {
            _context.NurseRoomAssignations.Add(nurseRoomAssignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNurseRoomAssignation", new { id = nurseRoomAssignation.Id }, nurseRoomAssignation);
        }

        // DELETE: api/NurseRoomAssignations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NurseRoomAssignation>> DeleteNurseRoomAssignation(Guid id)
        {
            var nurseRoomAssignation = await _context.NurseRoomAssignations.FindAsync(id);
            if (nurseRoomAssignation == null)
            {
                return NotFound();
            }

            _context.NurseRoomAssignations.Remove(nurseRoomAssignation);
            await _context.SaveChangesAsync();

            return nurseRoomAssignation;
        }

        private bool NurseRoomAssignationExists(Guid id)
        {
            return _context.NurseRoomAssignations.Any(e => e.Id == id);
        }
    }
}
