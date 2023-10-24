using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Usuario
    {
        [Key]

        public int codUsuario { get; set; }

        public string nombre { get; set; }

        public int dni { get; set; }

        public int tipo { get; set; } //(1 – Administrador, 2 – Consultor)

        public string contrasena { get; set; }
    }

    public class UsuarioDTO
    {
        public string nombre { get; set; }

        public int dni { get; set; }

        public int tipo { get; set; } //(1 – Administrador, 2 – Consultor)

        public string contrasena { get; set; }
    }

}
