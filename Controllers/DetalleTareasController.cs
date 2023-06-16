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
    public class DetalleTareasController : ControllerBase
    {
        private readonly LPBD_BDContext _context;

        public DetalleTareasController(LPBD_BDContext context)
        {
            _context = context;
        }

        //// GET: api/DetalleTareas
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<DetalleTarea>>> GetDetalleTareas()
        //{
        //    if (_context.DetalleTareas == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.DetalleTareas.ToListAsync();
        //}

        //// GET: api/DetalleTareas/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<DetalleTarea>> GetDetalleTarea(int id)
        //{
        //    if (_context.DetalleTareas == null)
        //    {
        //        return NotFound();
        //    }
        //    var detalleTarea = await _context.DetalleTareas.FindAsync(id);

        //    if (detalleTarea == null)
        //    {
        //        return NotFound();
        //    }

        //    return detalleTarea;
        //}

        //// PUT: api/DetalleTareas/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDetalleTarea(int id, DetalleTarea detalleTarea)
        //{
        //    if (id != detalleTarea.IdDetTar)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(detalleTarea).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DetalleTareaExists(id))
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

        // POST: api/DetalleTareas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDetalleTarea(int idTarea, int idPersonal)
        {
            try
            {
                var detalleTarea = new DetalleTarea();
                detalleTarea.IdTar = idTarea;
                detalleTarea.IdPer = idPersonal;
                _context.DetalleTareas.Add(detalleTarea);
                await _context.SaveChangesAsync();
                return Ok(detalleTarea);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // DELETE: api/DetalleTareas/5
        [HttpDelete("{id},{id2}")]
        public async Task<IActionResult> DeleteDetalleTarea(int id, int id2)
        {
            try {
                var detalleTarea = await _context.DetalleTareas.Where(tarea => tarea.IdTar == id && tarea.IdPer == id2).FirstOrDefaultAsync();
                if (detalleTarea == null)
                {
                    return NotFound();
                }
                _context.DetalleTareas.Remove(detalleTarea);
                await _context.SaveChangesAsync();
                return Ok(detalleTarea );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private bool DetalleTareaExists(int id)
        {
            return (_context.DetalleTareas?.Any(e => e.IdDetTar == id)).GetValueOrDefault();
        }
    }
}
