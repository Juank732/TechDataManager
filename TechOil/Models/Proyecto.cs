using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Proyecto
    {
        [Key]
        public int? codProyecto { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public int estado { get; set; } //1 – Pendiente, 2 – Confirmado, 3 – Terminado)



    }

    //public class ProyectoDTO
    //{
    //    public string nombre { get; set; }
    //    public string direccion { get; set; }
    //    public int estado { get; set; }
    //}



}
