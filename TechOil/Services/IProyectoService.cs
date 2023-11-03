using TechOil.Models;

namespace TechOil.Services
{
    public interface IProyectoService
    {
        Task<IEnumerable<Proyecto>> ObtenerTodosLosProyectos();
        Task<Proyecto> ObtenerProyecto(int codProyecto);

        Task<IEnumerable<Proyecto>> ObtenerProyectoPorEstado(int estado);

        Task AñadirProyecto(Proyecto proyecto);

        Task ActualizarProyecto(Proyecto proyecto);

        Task EliminarProyecto(int codProyecto);

    }





}
