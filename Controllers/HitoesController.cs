using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LPBD_Backend.Models;

namespace LPBD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HitoesController : ControllerBase
    {
        private readonly LPBD_BDContext _context;

        public HitoesController(LPBD_BDContext context)
        {
            _context = context;
        }

        // GET: api/Hitoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hito>>> GetHitos()
        {
          if (_context.Hitos == null)
          {
              return NotFound();
          }
            return await _context.Hitos.ToListAsync();
        }

        // GET: api/Hitoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hito>> GetHito(int id)
        {
          if (_context.Hitos == null)
          {
              return NotFound();
          }
            var hito = await _context.Hitos.FindAsync(id);

            if (hito == null)
            {
                return NotFound();
            }

            return hito;
        }

        // PUT: api/Hitoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHito(int id, Hito hito)
        {
            if (id != hito.IdHit)
            {
                return BadRequest();
            }

            _context.Entry(hito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HitoExists(id))
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

        // POST: api/Hitoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hito>> PostHito(Hito hito)
        {
          if (_context.Hitos == null)
          {
              return Problem("Entity set 'LPBD_BDContext.Hitos'  is null.");
          }
            _context.Hitos.Add(hito);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HitoExists(hito.IdHit))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHito", new { id = hito.IdHit }, hito);
        }

        // DELETE: api/Hitoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHito(int id)
        {
            if (_context.Hitos == null)
            {
                return NotFound();
            }
            var hito = await _context.Hitos.FindAsync(id);
            if (hito == null)
            {
                return NotFound();
            }

            _context.Hitos.Remove(hito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HitoExists(int id)
        {
            return (_context.Hitos?.Any(e => e.IdHit == id)).GetValueOrDefault();
        }
    }
}
