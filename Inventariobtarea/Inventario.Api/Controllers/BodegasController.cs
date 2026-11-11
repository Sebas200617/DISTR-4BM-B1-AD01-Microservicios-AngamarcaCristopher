using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public BodegasController(InventarioDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
        {
            var lista = await _context.Bodega
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var item = await _context.Bodega
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdBodega == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<Bodega>> CrearBodega(Bodega item)
        {
            _context.Bodega.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetBodega),
                new { id = item.IdBodega },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarBodega(int id, Bodega item)
        {
            if (id != item.IdBodega)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarBodega(int id)
        {
            var item = await _context.Bodega.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Bodega.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}