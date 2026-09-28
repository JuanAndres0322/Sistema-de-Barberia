using System;
using System.Collections.Generic;
using System.Text;

namespace lib_Barberia.Entidades
{
    public class Clientes
    {
        public int ID_Cliente { get; set; }
        public string Cedula { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public List<Citas>? Citas { get; set; }
        public List<VentaProductos>? VentaProductos { get; set; }
    }
}
