using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly PedidosDBContext _context;

        public ClientesController(PedidosDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var lista = await _context.Cliente
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var item = await _context.Cliente
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdCliente == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente item)
        {
            _context.Cliente.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCliente),
                new { id = item.IdCliente },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, Cliente item)
        {
            if (id != item.IdCliente)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCliente(int id)
        {
            var item = await _context.Cliente.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Cliente.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}