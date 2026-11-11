using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasStockController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public ReservasStockController(InventarioDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaStock>>> GetReservasStock()
        {
            var lista = await _context.ReservaStock
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaStock>> GetReservaStock(int id)
        {
            var item = await _context.ReservaStock
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdReserva == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ReservaStock>> CrearReservaStock(ReservaStock item)
        {
            _context.ReservaStock.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetReservaStock),
                new { id = item.IdReserva },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarReservaStock(int id, ReservaStock item)
        {
            if (id != item.IdReserva)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarReservaStock(int id)
        {
            var item = await _context.ReservaStock.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.ReservaStock.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}