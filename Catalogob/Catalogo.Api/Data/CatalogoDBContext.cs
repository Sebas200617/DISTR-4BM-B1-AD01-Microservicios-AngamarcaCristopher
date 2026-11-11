using Microsoft.EntityFrameworkCore;

namespace Catalogo.Api.Data
{
    public class CatalogoDBContext : DbContext
    {
        public CatalogoDBContext(DbContextOptions<CatalogoDBContext> options) : base(options)
        {
        }

        public DbSet<Models.Marca> Marca { get; set; }
        public DbSet<Models.Categoria> Categoria { get; set; }
        public DbSet<Models.Producto> Producto { get; set; }
    }
}
