using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class PromocionesTest : BaseTest
    {
        private Promociones? entidad;

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
            entidad = new Promociones
            {
                Nombre = "Promocion de prueba",
                TipoDescuento = "Porcentaje (%)",
                ValorDescuento = 10m,
                FechaInicio = new DateTime(2026, 1, 1),
                FechaFin = new DateTime(2026, 12, 31),
                Activo = true
            };
            iConexion.Promociones!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Promocion > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Promocion modificada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Promociones!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Promociones!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
