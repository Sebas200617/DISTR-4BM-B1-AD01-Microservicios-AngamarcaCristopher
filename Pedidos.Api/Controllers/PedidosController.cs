using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDBContext _context;

        public PedidosController(PedidosDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            var lista = await _context.Pedido
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var item = await _context.Pedido
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdPedido == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<Pedido>> CrearPedido(Pedido item)
        {
            _context.Pedido.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetPedido),
                new { id = item.IdPedido },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedido(int id, Pedido item)
        {
            if (id != item.IdPedido)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarPedido(int id)
        {
            var item = await _context.Pedido.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Pedido.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}