using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class ServiciosTest : BaseTest
    {
        private Servicios? entidad;

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
            entidad = new Servicios
            {
                Nombre = "Servicio de prueba",
                Descripcion = "Descripcion de prueba",
                DuracionMinutos = 30,
                PrecioActual = 10000m,
                Activo = true
            };
            iConexion.Servicios!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Servicio > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Servicio modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Servicios!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Servicios!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
