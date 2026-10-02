using System.ComponentModel.DataAnnotations;
namespace lib_Barberia.Entidades
{
    public class MetodosPago
    {
        [Key]
        public int ID_Metodo { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }

        public List<Pagos>? Pagos { get; set; }
    }
}
