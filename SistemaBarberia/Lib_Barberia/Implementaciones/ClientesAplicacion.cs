using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? iConexion = null;

        public ClientesAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Clientes> Listar()
        {
            return this.iConexion!.Clientes!.ToList();
        }

        public Clientes Guardar(Clientes entidad)
        {
            this.iConexion!.Clientes!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Clientes Modificar(Clientes entidad)
        {
            var entry = this.iConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            this.iConexion!.Clientes!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
