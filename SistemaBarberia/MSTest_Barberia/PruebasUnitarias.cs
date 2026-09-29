using lib_Barberia.Entidades;
using lib_Barberia.Implementaciones;
using lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MSTest_Barberia
{
    public abstract class BaseTest
    {
        protected readonly IConexion iConexion;

        protected BaseTest()
        {
            iConexion = new Conexion
            {
                StringConexion = "Server=localhost;Database=BD_Barberia;Trusted_Connection=True;TrustServerCertificate=True;"
            };
        }

        protected void Actualizar(object entidad)
        {
            iConexion.Entry(entidad).State = EntityState.Modified;
            iConexion.SaveChanges();
        }
    }


    [TestClass]
    public class ClientesTest : BaseTest
    {
        private Clientes? entidad;

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
            iConexion.Clientes!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Cliente > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Cliente modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Clientes!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Clientes!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class BarberosTest : BaseTest
    {
        private Barberos? entidad;

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
            entidad = new Barberos
            {
                Cedula = "99999",
                Nombre = "Barbero de prueba",
                Telefono = "3000000000",
                Especialidad = "Prueba",
                Activo = true
            };
            iConexion.Barberos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Barbero > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Barbero modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Barberos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Barberos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

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

    [TestClass]
    public class CategoriasProductoTest : BaseTest
    {
        private CategoriasProducto? entidad;

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
            iConexion.CategoriasProducto!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Categoria > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Categoria modificada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.CategoriasProducto!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.CategoriasProducto!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class ProveedoresTest : BaseTest
    {
        private Proveedores? entidad;

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
            entidad = new Proveedores
            {
                NIT = "999999999",
                NombreEmpresa = "Proveedor de prueba",
                ContactoPrincipal = "Contacto de prueba",
                Telefono = "3000000000",
                Email = "prueba@proveedor.com"
            };
            iConexion.Proveedores!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Proveedor > 0;
        }

        private bool Modificar()
        {
            entidad!.NombreEmpresa = "Proveedor modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Proveedores!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Proveedores!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class SucursalesTest : BaseTest
    {
        private Sucursales? entidad;

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
            entidad = new Sucursales
            {
                Nombre = "Sucursal de prueba",
                Direccion = "Calle 1 # 2-3",
                Telefono = "6040000000",
                Ciudad = "Medellin",
                Activa = true
            };
            iConexion.Sucursales!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Sucursal > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Sucursal modificada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Sucursales!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Sucursales!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

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

    [TestClass]
    public class RolesTest : BaseTest
    {
        private Roles? entidad;

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
            entidad = new Roles
            {
                Nombre = "Rol de prueba",
                Descripcion = "Descripcion de prueba",
                Activo = true
            };
            iConexion.Roles!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Rol > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Rol modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Roles!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Roles!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class PermisosTest : BaseTest
    {
        private Permisos? entidad;

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
            entidad = new Permisos
            {
                NombrePermiso = "Permiso de prueba",
                ModuloApp = "Pruebas",
                Descripcion = "Descripcion de prueba"
            };
            iConexion.Permisos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Permiso > 0;
        }

        private bool Modificar()
        {
            entidad!.NombrePermiso = "Permiso modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Permisos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Permisos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class CitasTest : BaseTest
    {
        private Citas? entidad;

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
            entidad = new Citas
            {
                ID_Cliente = iConexion.Clientes!.First().ID_Cliente,
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                FechaHora = DateTime.Now,
                Estado = "Pendiente",
                NotasAdicionales = "Prueba"
            };
            iConexion.Citas!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Cita > 0;
        }

        private bool Modificar()
        {
            entidad!.Estado = "Confirmada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Citas!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Citas!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class CitaServiciosTest : BaseTest
    {
        private CitaServicios? entidad;

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
            entidad = new CitaServicios
            {
                ID_Cita = iConexion.Citas!.First().ID_Cita,
                ID_Servicio = iConexion.Servicios!.First().ID_Servicio,
                PrecioCobrado = 20000m,
                DescuentoAplicado = 0m
            };
            iConexion.CitaServicios!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_CitaServicio > 0;
        }

        private bool Modificar()
        {
            entidad!.PrecioCobrado = 25000m;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.CitaServicios!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.CitaServicios!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class PagosTest : BaseTest
    {
        private Pagos? entidad;

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
            entidad = new Pagos
            {
                ID_Cita = iConexion.Citas!.First().ID_Cita,
                ID_Metodo = iConexion.MetodosPago!.First().ID_Metodo,
                MontoTotal = 20000m,
                FechaPago = DateTime.Now,
                ReferenciaVoucher = "VOU-PRUEBA"
            };
            iConexion.Pagos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Pago > 0;
        }

        private bool Modificar()
        {
            entidad!.MontoTotal = 30000m;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Pagos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Pagos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class HorariosDisponibilidadTest : BaseTest
    {
        private HorariosDisponibilidad? entidad;

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
            entidad = new HorariosDisponibilidad
            {
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                DiaSemana = "Sabado",
                HoraInicio = new TimeSpan(9, 0, 0),
                HoraFin = new TimeSpan(17, 0, 0),
                Estado = "Activo"
            };
            iConexion.HorariosDisponibilidad!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Horario > 0;
        }

        private bool Modificar()
        {
            entidad!.Estado = "Inactivo";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.HorariosDisponibilidad!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.HorariosDisponibilidad!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class ProductosTest : BaseTest
    {
        private Productos? entidad;

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
            entidad = new Productos
            {
                ID_Categoria = iConexion.CategoriasProducto!.First().ID_Categoria,
                ID_Proveedor = iConexion.Proveedores!.First().ID_Proveedor,
                Nombre = "Producto de prueba",
                CodigoBarras = "0000000000000",
                PrecioVenta = 10000m,
                StockActual = 10
            };
            iConexion.Productos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Producto > 0;
        }

        private bool Modificar()
        {
            entidad!.Nombre = "Producto modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Productos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Productos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class VentaProductosTest : BaseTest
    {
        private VentaProductos? entidad;

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
            entidad = new VentaProductos
            {
                ID_Cliente = iConexion.Clientes!.First().ID_Cliente,
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                FechaVenta = DateTime.Now,
                TotalVenta = 10000m,
                EstadoVenta = "Pendiente"
            };
            iConexion.VentaProductos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Venta > 0;
        }

        private bool Modificar()
        {
            entidad!.EstadoVenta = "Pagada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.VentaProductos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.VentaProductos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class DetalleVentaProductosTest : BaseTest
    {
        private DetalleVentaProductos? entidad;

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
            entidad = new DetalleVentaProductos
            {
                ID_Venta = iConexion.VentaProductos!.First().ID_Venta,
                ID_Producto = iConexion.Productos!.First().ID_Producto,
                Cantidad = 1,
                PrecioUnitario = 10000m,
                Subtotal = 10000m
            };
            iConexion.DetalleVentaProductos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Detalle > 0;
        }

        private bool Modificar()
        {
            entidad!.Cantidad = 2;
            entidad.Subtotal = 20000m;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.DetalleVentaProductos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.DetalleVentaProductos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class CajasDiariasTest : BaseTest
    {
        private CajasDiarias? entidad;

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
            entidad = new CajasDiarias
            {
                ID_Sucursal = iConexion.Sucursales!.First().ID_Sucursal,
                FechaApertura = DateTime.Now,
                SaldoInicial = 100000m,
                SaldoFinal = 100000m,
                EstadoCaja = "Abierta"
            };
            iConexion.CajasDiarias!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Caja > 0;
        }

        private bool Modificar()
        {
            entidad!.EstadoCaja = "Cerrada";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.CajasDiarias!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.CajasDiarias!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class RolPermisosTest : BaseTest
    {
        private RolPermisos? entidad;

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
            entidad = new RolPermisos
            {
                ID_Rol = iConexion.Roles!.First().ID_Rol,
                ID_Permiso = iConexion.Permisos!.First().ID_Permiso,
                FechaAsignacion = DateTime.Now,
                Habilitado = true
            };
            iConexion.RolPermisos!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_RolPermiso > 0;
        }

        private bool Modificar()
        {
            entidad!.Habilitado = false;
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.RolPermisos!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.RolPermisos!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }

    [TestClass]
    public class UsuariosTest : BaseTest
    {
        private Usuarios? entidad;

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
            entidad = new Usuarios
            {
                ID_Rol = iConexion.Roles!.First().ID_Rol,
                ID_Barbero = iConexion.Barberos!.First().ID_Barbero,
                NombreUsuario = "usuario_prueba",
                HashContrasena = "hash_prueba***",
                UltimoAcceso = DateTime.Now
            };
            iConexion.Usuarios!.Add(entidad);
            iConexion.SaveChanges();
            return entidad.ID_Usuario > 0;
        }

        private bool Modificar()
        {
            entidad!.NombreUsuario = "usuario_modificado";
            Actualizar(entidad);
            return true;
        }

        private bool Listar() => iConexion.Usuarios!.ToList().Count > 0;

        private bool Borrar()
        {
            iConexion.Usuarios!.Remove(entidad!);
            iConexion.SaveChanges();
            return true;
        }
    }
}
