using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Barberia.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        public DbSet<Barberos>? Barberos { get; set; }
        public DbSet<CajasDiarias>? CajasDiarias { get; set; }
        public DbSet<CategoriasProducto>? CategoriasProducto { get; set; }
        public DbSet<CitaServicios>? CitaServicios { get; set; }
        public DbSet<Citas>? Citas { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<DetalleVentaProductos>? DetalleVentaProductos { get; set; }
        public DbSet<HorariosDisponibilidad>? HorariosDisponibilidad { get; set; }
        public DbSet<MetodosPago>? MetodosPago { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Permisos>? Permisos { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<RolPermisos>? RolPermisos { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Servicios>? Servicios { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<VentaProductos>? VentaProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CajasDiarias>().ToTable("Cajas_Diarias");
            modelBuilder.Entity<CategoriasProducto>().ToTable("Categorias_Producto");
            modelBuilder.Entity<CitaServicios>().ToTable("Cita_Servicios");
            modelBuilder.Entity<DetalleVentaProductos>().ToTable("Detalle_Venta_Productos");
            modelBuilder.Entity<HorariosDisponibilidad>().ToTable("Horarios_Disponibilidad");
            modelBuilder.Entity<MetodosPago>().ToTable("Metodos_Pago");
            modelBuilder.Entity<RolPermisos>().ToTable("Rol_Permisos");
            modelBuilder.Entity<VentaProductos>().ToTable("Venta_Productos");

            modelBuilder.Entity<Barberos>().HasKey(x => x.ID_Barbero);
            modelBuilder.Entity<CajasDiarias>().HasKey(x => x.ID_Caja);
            modelBuilder.Entity<CategoriasProducto>().HasKey(x => x.ID_Categoria);
            modelBuilder.Entity<CitaServicios>().HasKey(x => x.ID_CitaServicio);
            modelBuilder.Entity<Citas>().HasKey(x => x.ID_Cita);
            modelBuilder.Entity<Clientes>().HasKey(x => x.ID_Cliente);
            modelBuilder.Entity<DetalleVentaProductos>().HasKey(x => x.ID_Detalle);
            modelBuilder.Entity<HorariosDisponibilidad>().HasKey(x => x.ID_Horario);
            modelBuilder.Entity<MetodosPago>().HasKey(x => x.ID_Metodo);
            modelBuilder.Entity<Pagos>().HasKey(x => x.ID_Pago);
            modelBuilder.Entity<Permisos>().HasKey(x => x.ID_Permiso);
            modelBuilder.Entity<Productos>().HasKey(x => x.ID_Producto);
            modelBuilder.Entity<Promociones>().HasKey(x => x.ID_Promocion);
            modelBuilder.Entity<Proveedores>().HasKey(x => x.ID_Proveedor);
            modelBuilder.Entity<RolPermisos>().HasKey(x => x.ID_RolPermiso);
            modelBuilder.Entity<Roles>().HasKey(x => x.ID_Rol);
            modelBuilder.Entity<Servicios>().HasKey(x => x.ID_Servicio);
            modelBuilder.Entity<Sucursales>().HasKey(x => x.ID_Sucursal);
            modelBuilder.Entity<Usuarios>().HasKey(x => x.ID_Usuario);
            modelBuilder.Entity<VentaProductos>().HasKey(x => x.ID_Venta);

            modelBuilder.Entity<Clientes>().Property(x => x.CorreoElectronico).HasColumnName("Correo_Electronico");
            modelBuilder.Entity<Clientes>().Property(x => x.FechaNacimiento).HasColumnName("Fecha_Nacimiento");

            modelBuilder.Entity<Usuarios>().Property(x => x.NombreUsuario).HasColumnName("Nombre_Usuario");
            modelBuilder.Entity<Usuarios>().Property(x => x.HashContrasena).HasColumnName("Hash_Contrasena");
            modelBuilder.Entity<Usuarios>().Property(x => x.UltimoAcceso).HasColumnName("Ultimo_Acceso");

            modelBuilder.Entity<VentaProductos>().Property(x => x.FechaVenta).HasColumnName("Fecha_Venta");
            modelBuilder.Entity<VentaProductos>().Property(x => x.TotalVenta).HasColumnName("Total_Venta").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<VentaProductos>().Property(x => x.EstadoVenta).HasColumnName("Estado_Venta");

            modelBuilder.Entity<Productos>().Property(x => x.CodigoBarras).HasColumnName("Codigo_Barras");
            modelBuilder.Entity<Productos>().Property(x => x.PrecioVenta).HasColumnName("Precio_Venta").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Productos>().Property(x => x.StockActual).HasColumnName("Stock_Actual");

            modelBuilder.Entity<Servicios>().Property(x => x.DuracionMinutos).HasColumnName("Duracion_Minutos");
            modelBuilder.Entity<Servicios>().Property(x => x.PrecioActual).HasColumnName("Precio_Actual").HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Citas>().Property(x => x.FechaHora).HasColumnName("Fecha_Hora");
            modelBuilder.Entity<Citas>().Property(x => x.NotasAdicionales).HasColumnName("Notas_Adicionales");

            modelBuilder.Entity<Proveedores>().Property(x => x.NombreEmpresa).HasColumnName("Nombre_Empresa");
            modelBuilder.Entity<Proveedores>().Property(x => x.ContactoPrincipal).HasColumnName("Contacto_Principal");

            modelBuilder.Entity<Promociones>().Property(x => x.TipoDescuento).HasColumnName("Tipo_Descuento");
            modelBuilder.Entity<Promociones>().Property(x => x.ValorDescuento).HasColumnName("Valor_Descuento").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Promociones>().Property(x => x.FechaInicio).HasColumnName("Fecha_Inicio");
            modelBuilder.Entity<Promociones>().Property(x => x.FechaFin).HasColumnName("Fecha_Fin");

            modelBuilder.Entity<Permisos>().Property(x => x.NombrePermiso).HasColumnName("Nombre_Permiso");
            modelBuilder.Entity<Permisos>().Property(x => x.ModuloApp).HasColumnName("Modulo_App");

            modelBuilder.Entity<CitaServicios>().Property(x => x.PrecioCobrado).HasColumnName("Precio_Cobrado").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<CitaServicios>().Property(x => x.DescuentoAplicado).HasColumnName("Descuento_Aplicado").HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Pagos>().Property(x => x.MontoTotal).HasColumnName("Monto_Total").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Pagos>().Property(x => x.FechaPago).HasColumnName("Fecha_Pago");
            modelBuilder.Entity<Pagos>().Property(x => x.ReferenciaVoucher).HasColumnName("Referencia_Voucher");

            modelBuilder.Entity<HorariosDisponibilidad>().Property(x => x.DiaSemana).HasColumnName("Dia_Semana");
            modelBuilder.Entity<HorariosDisponibilidad>().Property(x => x.HoraInicio).HasColumnName("Hora_Inicio");
            modelBuilder.Entity<HorariosDisponibilidad>().Property(x => x.HoraFin).HasColumnName("Hora_Fin");

            modelBuilder.Entity<DetalleVentaProductos>().Property(x => x.PrecioUnitario).HasColumnName("Precio_Unitario").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<DetalleVentaProductos>().Property(x => x.Subtotal).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<CajasDiarias>().Property(x => x.FechaApertura).HasColumnName("Fecha_Apertura");
            modelBuilder.Entity<CajasDiarias>().Property(x => x.SaldoInicial).HasColumnName("Saldo_Inicial").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<CajasDiarias>().Property(x => x.SaldoFinal).HasColumnName("Saldo_Final").HasColumnType("decimal(10,2)");
            modelBuilder.Entity<CajasDiarias>().Property(x => x.EstadoCaja).HasColumnName("Estado_Caja");

            modelBuilder.Entity<RolPermisos>().Property(x => x.FechaAsignacion).HasColumnName("Fecha_Asignacion");
        }
    }
}
