using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("MovimientosInv")]
    public class MovimientosInv
    {
        [Key]
        [Column("IdMovimiento")]
        public int IdMovimiento { get; set; }

        // Referencia logica a CatalogoDB.Producto (otra base de datos, sin FK fisica)
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("IdBodega")]
        public int IdBodega { get; set; }

        [StringLength(10)]
        [Column("Tipo")]
        public string Tipo { get; set; } = string.Empty;   // ENTRADA / SALIDA

        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
