using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lib_Barberia.Entidades
{
    public class CajasDiarias
    {
        [Key]
        public int ID_Caja { get; set; }

        public int? ID_Sucursal { get; set; }
        [ForeignKey("ID_Sucursal")]
        public Sucursales? Sucursal { get; set; }

        public DateTime? FechaApertura { get; set; }
        public decimal? SaldoInicial { get; set; }
        public decimal? SaldoFinal { get; set; }
        public string? EstadoCaja { get; set; }
    }
}
