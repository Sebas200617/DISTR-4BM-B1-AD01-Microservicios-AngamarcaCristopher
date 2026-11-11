using Microsoft.EntityFrameworkCore;

namespace Inventario.Api.Data
{
    public class InventarioDBContext : DbContext
    {
        public InventarioDBContext(DbContextOptions<InventarioDBContext> options) : base(options)
        {
        }

        public DbSet<Models.Bodega> Bodega { get; set; }
        public DbSet<Models.Existencias> Existencias { get; set; }
        public DbSet<Models.MovimientosInv> MovimientosInv { get; set; }
        public DbSet<Models.ReservaStock> ReservaStock { get; set; }
    }
}
