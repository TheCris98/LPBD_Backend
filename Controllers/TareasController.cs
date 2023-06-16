using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LPBD_Backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace LPBD_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TareasController : ControllerBase
    {
        private readonly LPBD_BDContext _context;

        public TareasController(LPBD_BDContext context)
        {
            _context = context;
        }

        // GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            if (_context.Tareas == null)
            {
                return NotFound();
            }
            return await _context.Tareas.ToListAsync();
        }

        //// GET: api/Tareas/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Tarea>> GetTarea(int id)
        //{
        //  if (_context.Tareas == null)
        //  {
        //      return NotFound();
        //  }
        //    var tarea = await _context.Tareas.FindAsync(id);

        //    if (tarea == null)
        //    {
        //        return NotFound();
        //    }

        //    return tarea;
        //}

        //// PUT: api/Tareas/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTarea(int id, Tarea tarea)
        //{
        //    if (id != tarea.IdTar)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tarea).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TareaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Tareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTarea(int id, [FromBody] Tarea tarea)
        {
            try
            {
                tarea.EstTar = 0;
                tarea.IdProTar = id;
                tarea.AvanceTar = 0;
                _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();
                return Ok(tarea);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //        // DELETE: api/Tareas/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteTarea(int id)
        //        {
        //            if (_context.Tareas == null)
        //            {
        //                return NotFound();
        //            }
        //            var tarea = await _context.Tareas.FindAsync(id);
        //            if (tarea == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Tareas.Remove(tarea);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool TareaExists(int id)
        //        {
        //            return (_context.Tareas?.Any(e => e.IdTar == id)).GetValueOrDefault();
        //        }
        //    }
        //}
    }
}