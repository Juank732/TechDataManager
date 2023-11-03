namespace TechOil.Models.DTO
{
    public class TrabajoDTO
    {
        public DateTime fecha { get; set; }

        public int cantHoras { get; set; }

        public decimal valorHora { get; set; }

        public decimal costo { get; set; }

        public int? codProyecto { get; set; }

        public int? codServicio { get; set; }
    }
}
