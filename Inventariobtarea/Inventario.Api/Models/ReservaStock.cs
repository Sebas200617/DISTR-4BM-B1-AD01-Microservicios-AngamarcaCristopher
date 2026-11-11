using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("ReservaStock")]
    public class ReservaStock
    {
        [Key]
        [Column("IdReserva")]
        public int IdReserva { get; set; }

        // Referencia logica a CatalogoDB.Producto (otra base de datos, sin FK fisica)
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("IdBodega")]
        public int IdBodega { get; set; }

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [StringLength(20)]
        [Column("Estado")]
        public string Estado { get; set; } = "ACTIVA";   // ACTIVA / CONFIRMADA / CANCELADA
    }
}
