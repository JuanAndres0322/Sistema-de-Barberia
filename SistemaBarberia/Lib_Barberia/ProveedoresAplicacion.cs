using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private IConexion? iConexion = null;

        public ProveedoresAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Proveedores> Listar()
        {
            return this.iConexion!.Proveedores!.ToList();
        }

        public Proveedores Guardar(Proveedores entidad)
        {
            this.iConexion!.Proveedores!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Proveedores Modificar(Proveedores entidad)
        {
            var entry = this.iConexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            this.iConexion!.Proveedores!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
