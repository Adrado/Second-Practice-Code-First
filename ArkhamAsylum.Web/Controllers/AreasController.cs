﻿using System;
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
    public class AreasController : ControllerBase
    {
        private readonly ArkhamAsylumDbContext _context;

        public AreasController(ArkhamAsylumDbContext context)
        {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            return await _context.Areas.ToListAsync();
        }

        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(Guid id)
        {
            var area = await _context.Areas.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(Guid id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/Areas
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.Id }, area);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Area>> DeleteArea(Guid id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return area;
        }

        private bool AreaExists(Guid id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
