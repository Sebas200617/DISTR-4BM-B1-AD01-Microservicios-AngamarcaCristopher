using Microsoft.EntityFrameworkCore;

namespace Pedidos.Api.Data
{
    public class PedidosDBContext : DbContext
    {
        public PedidosDBContext(DbContextOptions<PedidosDBContext> options) : base(options)
        {
        }

        public DbSet<Models.Cliente> Cliente { get; set; }
        public DbSet<Models.Pedido> Pedido { get; set; }
        public DbSet<Models.DetallePedido> DetallePedido { get; set; }
    }
}
