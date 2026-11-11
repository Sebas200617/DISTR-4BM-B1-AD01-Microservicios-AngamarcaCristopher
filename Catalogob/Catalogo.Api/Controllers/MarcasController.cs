using Catalogo.Api.Data;
using Catalogo.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly CatalogoDBContext _context;

        public MarcasController(CatalogoDBContext context)
        {
            _context = context;
        }

        // Consultar todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var lista = await _context.Marca
                                      .AsNoTracking()
                                      .ToListAsync();

            return Ok(lista);
        }

        // Consultar por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var item = await _context.Marca
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.IdMarca == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<Marca>> CrearMarca(Marca item)
        {
            _context.Marca.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMarca),
                new { id = item.IdMarca },
                item
            );
        }

        // Actualizar
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMarca(int id, Marca item)
        {
            if (id != item.IdMarca)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarMarca(int id)
        {
            var item = await _context.Marca.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Marca.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}