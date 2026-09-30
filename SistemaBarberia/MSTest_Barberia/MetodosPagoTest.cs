using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class MetodosPagoTest : BaseTest
    {
        private MetodosPago? entidad;

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
            entidad = new MetodosPago
            {
                Nombre = "Metodo de prueba",
                Descripcion = "Descripcion de prueba",
                Activo = true
            };
            iConexion.MetodosPago!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Metodo > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Metodo modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.MetodosPago!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.MetodosPago!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
