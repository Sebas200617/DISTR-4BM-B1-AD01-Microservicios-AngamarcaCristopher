using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Api.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [StringLength(150)]
        [Column("Nombres")]
        public string Nombres { get; set; } = string.Empty;

        [StringLength(10)]
        [Column("Cedula")]
        public string Cedula { get; set; } = string.Empty;

        [StringLength(150)]
        [Column("Correo")]
        public string Correo { get; set; } = string.Empty;
    }
}
