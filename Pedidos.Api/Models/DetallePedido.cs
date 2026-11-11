using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Api.Models
{
    [Table("DetallePedido")]
    public class DetallePedido
    {
        [Key]
        [Column("IdDetalle")]
        public int IdDetalle { get; set; }

        [Column("IdPedido")]
        public int IdPedido { get; set; }

        // Referencia logica a CatalogoDB.Producto (otra base de datos, sin FK fisica)
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Column("PrecioUnitario", TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }
    }
}
