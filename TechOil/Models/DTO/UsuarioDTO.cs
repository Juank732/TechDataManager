namespace TechOil.Models.DTO
{
    public class UsuarioDTO
    {
        public string nombre { get; set; }

        public int dni { get; set; }

        public int tipo { get; set; } //(1 – Administrador, 2 – Consultor)

        public string contrasena { get; set; }
    }
}

