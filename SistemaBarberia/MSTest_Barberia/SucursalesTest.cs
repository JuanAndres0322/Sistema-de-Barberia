using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class SucursalesTest
    {
        private IConexion iConexion;
        private Sucursales? entidad;

        public SucursalesTest()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = DatosGenerales.ObtenerStringConnection();
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.IsTrue(Guardar());
            Assert.IsTrue(Modificar());
            Assert.IsTrue(Listar());
            Assert.IsTrue(Borrar());
        }

        private bool Guardar()
        {
            entidad = new Sucursales
            {
                Nombre = "Sucursal de prueba",
                Direccion = "Calle 1 # 2-3",
                Telefono = "6040000000",
                Ciudad = "Medellin",
                Activa = true
            };
            iConexion.Sucursales!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Sucursal > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Sucursal modificada";
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion.Sucursales!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Sucursales!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
