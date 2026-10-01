using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_Barberia.Entidades
{
    public class Productos
    {
        [Key]
        public int ID_Producto { get; set; }

        public int? ID_Categoria { get; set; }

        [ForeignKey("ID_Categoria")]
        public CategoriasProducto? Categoria { get; set; }

        public int? ID_Proveedor { get; set; }

        [ForeignKey("ID_Proveedor")]
        public Proveedores? Proveedor { get; set; }

        public string Nombre { get; set; } = null!;
        public string? CodigoBarras { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? StockActual { get; set; }

        public List<DetalleVentaProductos>? DetallesVenta { get; set; }
    }
}
