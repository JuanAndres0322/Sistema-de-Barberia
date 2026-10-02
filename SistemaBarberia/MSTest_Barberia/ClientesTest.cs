using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class ClientesTest
    {
        private IConexion? iConexion;
        private Clientes? entidad;

        public ClientesTest()
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
            entidad = new Clientes
            {
                Cedula = "99999",
                Nombre = "Cliente de prueba",
                Telefono = "3000000000",
                CorreoElectronico = "prueba@correo.com",
                FechaNacimiento = new DateTime(2000, 1, 1)
            };
            iConexion?.Clientes!.Add(entidad);
            iConexion?.SaveChanges();
            return entidad?.ID_Cliente > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Cliente modificado";
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion?.Clientes!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion?.Clientes!.Remove(entidad!);
            iConexion?.SaveChanges();
            return true;
        }
    }
}
