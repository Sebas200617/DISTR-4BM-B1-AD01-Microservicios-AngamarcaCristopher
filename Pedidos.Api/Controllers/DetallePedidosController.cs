using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidosController : ControllerBase
    {
        private readonly PedidosDBContext _context;

        public DetallePedidosController(PedidosDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallePedidos()
        {
            var lista = await _context.DetallePedido
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
            var item = await _context.DetallePedido
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdDetalle == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> CrearDetallePedido(DetallePedido item)
        {
            _context.DetallePedido.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetDetallePedido),
                new { id = item.IdDetalle },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDetallePedido(int id, DetallePedido item)
        {
            if (id != item.IdDetalle)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarDetallePedido(int id)
        {
            var item = await _context.DetallePedido.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.DetallePedido.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}