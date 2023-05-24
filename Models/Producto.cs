using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SaleWeb.Models
{
    public class Producto
    {
        [DisplayName("ID")]
        public int Idproducto { get; set; }
        [Required]
        [DisplayName("Producto")]
        public string? Nombre { get; set; }
        [Required]
        [DisplayName("Descripcion")]
        public string? Descripcion { get; set; }
        [Required]
        [DisplayName("Color")]
        public string? Color { get; set; }
        [Required]
        [DisplayName("Dimensiones")]
        public string? Dimensiones { get; set; }
        [DisplayName("Foto")]
        public byte[]? Foto { get; set; }
        [Required]
        [DisplayName("Precio")]
        public decimal? Precio { get; set; }

        [DisplayName("OrdenCompra")]
        public int? Idordencompra { get; set; }
        [Required]
        [DisplayName("Inventario")]
        public int? Idinventario { get; set; }
        [Required]
        [DisplayName("Categoria")]
        public int? Idcategoriaproducto { get; set; }
    }
}
