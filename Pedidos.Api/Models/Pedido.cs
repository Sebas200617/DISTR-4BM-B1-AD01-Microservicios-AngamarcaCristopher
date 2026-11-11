using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Api.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Column("IdPedido")]
        public int IdPedido { get; set; }

        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column("Total", TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }

        [StringLength(20)]
        [Column("Estado")]
        public string Estado { get; set; } = "PENDIENTE";   // PENDIENTE / CONFIRMADO / CANCELADO
    }
}