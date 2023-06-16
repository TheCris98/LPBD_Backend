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
    public class ProyectoesController : ControllerBase
    {
        private readonly LPBD_BDContext _context;

        public ProyectoesController(LPBD_BDContext context)
        {
            _context = context;
        }

        // GET: api/Proyectoes
        [HttpGet]
        [Route("proyectosUsuario")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos(int idUsuario)
        {
            if (_context.Proyectos == null)
            {
                return NotFound();
            }
            // Filtrar los proyectos por el idUsuario
            var proyectos = await _context.Proyectos
                .Where(p => p.DetalleProyectos.Any(up => up.IdPer == idUsuario))
                .ToListAsync();

            return proyectos;
        }

        [HttpGet]
        [Route("proyectosGerente")]
        public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectosGerente()
        {
            if (_context.Proyectos == null)
            {
                return NotFound();
            }
            // Filtrar los proyectos por el idUsuario
            return await _context.Proyectos.ToListAsync();
        }

        //// GET: api/Proyectoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleProyecto>> GetProyecto(int id)
        {
            try
            {
                var listaIntegrantes = await _context.DetalleProyectos.Where(inte => inte.IdPro == id).ToListAsync();
                foreach (var item in listaIntegrantes)
                {
                    return Ok();
                }
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// PUT: api/Proyectoes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
        //{
        //    if (id != proyecto.IdPro)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(proyecto).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProyectoExists(id))
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

        // POST: api/Proyectoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProyecto([FromBody] Proyecto proyecto)
        {
            try
            {
                _context.Proyectos.Add(proyecto);
                await _context.SaveChangesAsync();
                if(proyecto.DetalleProyectos != null)
                foreach (var item in proyecto.DetalleProyectos)
                {
                    item.IdPro = proyecto.IdPro;
                    _context.DetalleProyectos.Add(item);
                }
                await _context.SaveChangesAsync();
                return Ok(proyecto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //        // DELETE: api/Proyectoes/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteProyecto(int id)
        //        {
        //            if (_context.Proyectos == null)
        //            {
        //                return NotFound();
        //            }
        //            var proyecto = await _context.Proyectos.FindAsync(id);
        //            if (proyecto == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Proyectos.Remove(proyecto);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool ProyectoExists(int id)
        //        {
        //            return (_context.Proyectos?.Any(e => e.IdPro == id)).GetValueOrDefault();
        //        }
        //    }
        //}
    }
}
