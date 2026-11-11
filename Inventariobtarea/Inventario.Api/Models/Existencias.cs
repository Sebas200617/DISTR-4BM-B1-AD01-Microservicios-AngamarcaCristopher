using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Api.Models
{
    [Table("Existencia")]
    public class Existencias
    {
        [Key]
        [Column("IdExistencia")]
        public int IdExistencia { get; set; }

        // Referencia logica a CatalogoDB.Producto (otra base de datos, sin FK fisica)
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("IdBodega")]
        public int IdBodega { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }
    }
}