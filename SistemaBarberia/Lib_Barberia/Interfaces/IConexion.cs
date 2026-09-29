using lib_Barberia.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_Barberia.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Barberos>? Barberos { get; set; }
        DbSet<CajasDiarias>? CajasDiarias { get; set; }
        DbSet<CategoriasProducto>? CategoriasProducto { get; set; }
        DbSet<CitaServicios>? CitaServicios { get; set; }
        DbSet<Citas>? Citas { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<DetalleVentaProductos>? DetalleVentaProductos { get; set; }
        DbSet<HorariosDisponibilidad>? HorariosDisponibilidad { get; set; }
        DbSet<MetodosPago>? MetodosPago { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Permisos>? Permisos { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Promociones>? Promociones { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<RolPermisos>? RolPermisos { get; set; }
        DbSet<Roles>? Roles { get; set; }
        DbSet<Servicios>? Servicios { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<VentaProductos>? VentaProductos { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
