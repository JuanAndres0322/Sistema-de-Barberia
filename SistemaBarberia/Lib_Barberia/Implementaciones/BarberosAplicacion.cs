using lib_Barberia.Entidades;
using lib_Barberia.Interfaces;
using Lib_Barberia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib_Barberia.Implementaciones
{
    public class BarberosAplicacion : IBarberosAplicacion
    {
        // ===== Ajusta estos valores a los que realmente guardas en la BD =====
        private const string ESTADO_CITA_PENDIENTE = "Pendiente";
        private const string ESTADO_CITA_CONFIRMADA = "Confirmada";
        private const string ESTADO_VENTA_PENDIENTE = "Pendiente";
        private const string ESTADO_VENTA_CANCELADA = "Cancelada";
        private const string ESTADO_HORARIO_ACTIVO = "Activo";
        private const int DURACION_POR_DEFECTO = 30; // minutos, si la cita no tiene servicios

        private IConexion? iConexion = null;

        public BarberosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public List<Barberos> Listar()
        {
            return this.iConexion!.Barberos!.ToList();
        }

        public Barberos Guardar(Barberos entidad)
        {
            this.iConexion!.Barberos!.Add(entidad);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Barberos Modificar(Barberos entidad)
        {
            var entry = this.iConexion!.Entry<Barberos>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        /// <summary>
        /// Borrado lógico: el barbero queda inactivo y sus citas futuras se
        /// redistribuyen entre los barberos activos. El histórico se conserva.
        /// Todo se guarda en un único SaveChanges (atómico).
        /// </summary>
        public Barberos Borrar(Barberos entidad)
        {
            var db = this.iConexion!;

            var barbero = db.Barberos!.FirstOrDefault(b => b.ID_Barbero == entidad.ID_Barbero);
            if (barbero == null)
                throw new Exception("lbl_barbero_no_existe");

            var ahora = DateTime.Now;

            // 1. Citas futuras del barbero que se va (con la duración de sus servicios)
            var citasFuturas = db.Citas!
                .Include(c => c.CitaServicios!).ThenInclude(cs => cs.Servicio)
                .Where(c => c.ID_Barbero == barbero.ID_Barbero
                         && c.FechaHora > ahora
                         && (c.Estado == ESTADO_CITA_PENDIENTE || c.Estado == ESTADO_CITA_CONFIRMADA))
                .ToList();

            // 2. Barberos que pueden recibir la carga
            var candidatos = db.Barberos!
                .Where(b => b.ID_Barbero != barbero.ID_Barbero && b.Activo == true)
                .ToList();

            if (citasFuturas.Count > 0 && candidatos.Count == 0)
                throw new Exception("lbl_no_hay_barberos_activos_para_reasignar");

            var idsCandidatos = candidatos.Select(b => b.ID_Barbero).ToList();

            var horarios = db.HorariosDisponibilidad!
                .Where(h => h.ID_Barbero != null
                         && idsCandidatos.Contains(h.ID_Barbero.Value)
                         && h.Estado == ESTADO_HORARIO_ACTIVO)
                .ToList();

            var citasCandidatos = db.Citas!
                .Include(c => c.CitaServicios!).ThenInclude(cs => cs.Servicio)
                .Where(c => c.ID_Barbero != null
                         && idsCandidatos.Contains(c.ID_Barbero.Value)
                         && c.FechaHora > ahora
                         && (c.Estado == ESTADO_CITA_PENDIENTE || c.Estado == ESTADO_CITA_CONFIRMADA))
                .ToList();

            // Agenda en memoria de cada candidato: lista de (inicio, fin)
            var agenda = candidatos.ToDictionary(
                b => b.ID_Barbero,
                b => citasCandidatos
                        .Where(c => c.ID_Barbero == b.ID_Barbero)
                        .Select(c => (inicio: c.FechaHora!.Value,
                                      fin: c.FechaHora!.Value.AddMinutes(DuracionCita(c))))
                        .ToList());

            // 3. Calcular el plan SIN modificar entidades todavía
            var plan = new List<(Citas cita, int nuevoBarbero)>();
            var sinReasignar = new List<int>();

            foreach (var cita in citasFuturas.OrderBy(c => c.FechaHora))
            {
                var inicio = cita.FechaHora!.Value;
                var fin = inicio.AddMinutes(DuracionCita(cita));

                var elegido = candidatos
                    .Where(b => TrabajaEnHorario(horarios, b.ID_Barbero, inicio, fin)
                             && !HaySolape(agenda[b.ID_Barbero], inicio, fin))
                    .OrderBy(b => agenda[b.ID_Barbero].Count) // el de menor carga
                    .FirstOrDefault();

                if (elegido == null)
                {
                    sinReasignar.Add(cita.ID_Cita);
                    continue;
                }

                agenda[elegido.ID_Barbero].Add((inicio, fin)); // cuenta para las siguientes
                plan.Add((cita, elegido.ID_Barbero));
            }

            // Si alguna cita no se puede reasignar, no se toca nada
            if (sinReasignar.Count > 0)
                throw new Exception("lbl_citas_sin_reasignar: " + string.Join(", ", sinReasignar));

            // 4. Aplicar cambios
            foreach (var (cita, nuevoBarbero) in plan)
                cita.ID_Barbero = nuevoBarbero;

            // Ventas pendientes: se cancelan
            var ventasPendientes = db.VentaProductos!
                .Where(v => v.ID_Barbero == barbero.ID_Barbero
                         && v.EstadoVenta == ESTADO_VENTA_PENDIENTE)
                .ToList();
            foreach (var venta in ventasPendientes)
                venta.EstadoVenta = ESTADO_VENTA_CANCELADA;

            // Horarios: se eliminan (no son histórico)
            var horariosBarbero = db.HorariosDisponibilidad!
                .Where(h => h.ID_Barbero == barbero.ID_Barbero)
                .ToList();
            db.HorariosDisponibilidad!.RemoveRange(horariosBarbero);

            // Usuarios: se eliminan las cuentas del barbero (ninguna otra tabla referencia Usuarios)
            var usuarios = db.Usuarios!
                .Where(u => u.ID_Barbero == barbero.ID_Barbero)
                .ToList();
            db.Usuarios!.RemoveRange(usuarios);

            // Barbero: queda inactivo, la fila NO se borra
            barbero.Activo = false;

            db.SaveChanges();
            return barbero;
        }

        // ===================== Auxiliares =====================

        private static int DuracionCita(Citas cita)
        {
            int total = cita.CitaServicios?.Sum(cs => cs.Servicio?.DuracionMinutos ?? 0) ?? 0;
            return total > 0 ? total : DURACION_POR_DEFECTO;
        }

        private static bool HaySolape(List<(DateTime inicio, DateTime fin)> agenda,
                                      DateTime inicio, DateTime fin)
        {
            return agenda.Any(a => inicio < a.fin && fin > a.inicio);
        }

        // La comparación ignora tildes y mayúsculas; solo cambia esto si guardas el día de otra forma (p. ej. número)
        private static string NombreDia(DateTime fecha)
        {
            return fecha.DayOfWeek switch
            {
                DayOfWeek.Monday => "Lunes",
                DayOfWeek.Tuesday => "Martes",
                DayOfWeek.Wednesday => "Miércoles",
                DayOfWeek.Thursday => "Jueves",
                DayOfWeek.Friday => "Viernes",
                DayOfWeek.Saturday => "Sábado",
                _ => "Domingo"
            };
        }

        private static bool TrabajaEnHorario(List<HorariosDisponibilidad> horarios,
                                             int idBarbero, DateTime inicio, DateTime fin)
        {
            string dia = NombreDia(inicio);
            return horarios.Any(h => h.ID_Barbero == idBarbero
                                  && SinTildes(h.DiaSemana) == SinTildes(dia)
                                  && h.HoraInicio <= inicio.TimeOfDay
                                  && h.HoraFin >= fin.TimeOfDay);
        }

        // "Miércoles" y "Miercoles" (o "miércoles ") se comparan como iguales
        private static string SinTildes(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";
            var normalizado = texto.Trim().ToLowerInvariant().Normalize(System.Text.NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            foreach (var c in normalizado)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                    != System.Globalization.UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}