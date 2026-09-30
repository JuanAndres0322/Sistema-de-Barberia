using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class CitasAplicacion : ICitasAplicacion
    {
        private IConexion? iConexion = null;

        public CitasAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Citas> Listar()
        {
            return this.iConexion!.Citas!.ToList();
        }

        public Citas Guardar(Citas entidad)
        {
            this.iConexion!.Citas!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Citas Modificar(Citas entidad)
        {
            var entry = this.iConexion!.Entry<Citas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Citas Borrar(Citas entidad)
        {
            this.iConexion!.Citas!.Remove(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
