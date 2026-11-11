using Inventario.Api.Data;
using Inventario.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly InventarioDBContext _context;

        public ExistenciasController(InventarioDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencias>>> GetExistencias()
        {
            var lista = await _context.Existencias
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Existencias>> GetExistencia(int id)
        {
            var item = await _context.Existencias
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdExistencia == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<Existencias>> CrearExistencia(Existencias item)
        {
            _context.Existencias.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetExistencia),
                new { id = item.IdExistencia },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarExistencia(int id, Existencias item)
        {
            if (id != item.IdExistencia)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarExistencia(int id)
        {
            var item = await _context.Existencias.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Existencias.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}