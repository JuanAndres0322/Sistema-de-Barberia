using Lib_Barberia.Implementaciones; // Importar las implementaciones (si las tienes en otro namespace)
using Lib_Barberia.Interfaces; // Importar las interfaces
using lib_Barberia.Implementaciones; // Importar las implementaciones (si las tienes en otro namespace)
using lib_Barberia.Interfaces;
using Lib_Barberia.Nucleo; // Importar las interfaces
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// 1. Registrar IConexion usando tu clase DatosGenerales
builder.Services.AddScoped<IConexion>(provider =>
{
    var conexion = new Conexion();
    conexion.StringConexion = DatosGenerales.ObtenerStringConnection();
    return conexion;
});
// 🚨 REGISTRAR LAS DEPENDENCIAS - ¡ESTO ES LO QUE FALTA! 🚨
// 🚨 REGISTRO DE DEPENDENCIAS (Basado en tu imagen) 🚨
// Asegúrate de que los namespaces de Interfaces y Implementaciones estén importados si son diferentes.

builder.Services.AddScoped<IBarberosAplicacion, BarberosAplicacion>();
builder.Services.AddScoped<ICajasDiariasAplicacion, CajasDiariasAplicacion>();
builder.Services.AddScoped<ICategoriasProductoAplicacion, CategoriasProductoAplicacion>(); // Verifica el nombre exacto
builder.Services.AddScoped<ICitasAplicacion, CitasAplicacion>();
builder.Services.AddScoped<ICitaServiciosAplicacion, CitaServiciosAplicacion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<IDetalleVentaProductosAplicacion, DetalleVentaProductosAplicacion>(); // Verifica el nombre exacto
builder.Services.AddScoped<IHorariosDisponibilidadAplicacion, HorariosDisponibilidadAplicacion>();
builder.Services.AddScoped<IMetodosPagoAplicacion, MetodosPagoAplicacion>();
builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();
builder.Services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>(); // Verifica el nombre exacto
builder.Services.AddScoped<IPromocionesAplicacion, PromocionesAplicacion>();
builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<IRolPermisosAplicacion, RolPermisosAplicacion>();
builder.Services.AddScoped<IServiciosAplicacion, ServiciosAplicacion>();
builder.Services.AddScoped<ISucursalesAplicacion, SucursalesAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>(); // Verifica si es IUsers o IUsuario
builder.Services.AddScoped<IVentaProductosAplicacion, VentaProductosAplicacion>();
// Si tienes más interfaces, agrégalas aquí:
// builder.Services_DependsOn<IOtraInterfaz, OtraImplementacion>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();