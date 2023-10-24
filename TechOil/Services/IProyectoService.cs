using TechOil.Models;

namespace TechOil.Services
{
    public interface IProyectoService
    {
        IEnumerable<Proyecto> ObtenerTodosLosProyectos();
        Task<Proyecto> ObtenerProyecto(int codProyecto);

        public IEnumerable<Proyecto> ObtenerProyectoPorEstado(int estado); 

        Task AñadirProyecto(Proyecto proyecto);
  
        Task ActualizarProyecto(Proyecto proyecto);

        Task EliminarProyecto(int codProyecto);

    }





}
