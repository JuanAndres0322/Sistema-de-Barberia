using Web_Barberia.Acceso;

namespace Web_Barberia.Models
{
    public class FilaVM
    {
        public int Id { get; set; }
        public List<string> Celdas { get; set; } = new();
    }

    public class ListaVM
    {
        public EntidadInfo Info { get; set; } = null!;
        public List<Campo> Campos { get; set; } = new();
        public List<FilaVM> Filas { get; set; } = new();
        public string? Error { get; set; }
    }

    public class FormularioVM
    {
        public EntidadInfo Info { get; set; } = null!;
        public List<Campo> Campos { get; set; } = new();
        public Dictionary<string, string> Valores { get; set; } = new();
        public Dictionary<string, Dictionary<int, string>> Opciones { get; set; } = new();
        public List<string> Errores { get; set; } = new();
        public bool Editando { get; set; }
        public int Id { get; set; }
    }

    public class ConfirmarVM
    {
        public EntidadInfo Info { get; set; } = null!;
        public int Id { get; set; }
        public string Rotulo { get; set; } = "";
    }

    public class InicioVM
    {
        public string Direccion { get; set; } = "";
        public bool Conectada { get; set; }
        public string Mensaje { get; set; } = "";
    }
}
