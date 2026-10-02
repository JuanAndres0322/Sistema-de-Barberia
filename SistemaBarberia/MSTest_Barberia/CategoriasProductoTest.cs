using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    [TestClass]
    public class CategoriasProductoTest

    {
        private IConexion? iConexion;
        private CategoriasProducto? entidad;

        public CategoriasProductoTest()
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
            entidad = new CategoriasProducto
            {
                Nombre = "Categoria de prueba",
                Descripcion = "Descripcion de prueba",
                Activo = true
            };
            iConexion?.CategoriasProducto!.Add(entidad);
            iConexion?.SaveChanges();
            return entidad.ID_Categoria > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Categoria modificada";
            var entry = this.iConexion!.Entry(this.entidad!);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        private bool Listar() => iConexion?.CategoriasProducto!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion?.CategoriasProducto!.Remove(entidad!);
            iConexion?.SaveChanges();
            return true;
        }
    }
}
