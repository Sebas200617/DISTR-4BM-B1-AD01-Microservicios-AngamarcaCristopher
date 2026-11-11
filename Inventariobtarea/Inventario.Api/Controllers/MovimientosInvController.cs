using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosInvController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public MovimientosInvController(InventarioDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientosInv>>> GetMovimientosInventario()
        {
            var lista = await _context.MovimientosInv
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientosInv>> GetMovimientoInventario(int id)
        {
            var item = await _context.MovimientosInv
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdMovimiento == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<MovimientosInv>> CrearMovimientoInventario(MovimientosInv item)
        {
            _context.MovimientosInv.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMovimientoInventario),
                new { id = item.IdMovimiento },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMovimientoInventario(int id, MovimientosInv item)
        {
            if (id != item.IdMovimiento)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarMovimientoInventario(int id)
        {
            var item = await _context.MovimientosInv.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.MovimientosInv.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}