using TechOil.Models;

namespace TechOil.Services
{
    public interface ITrabajoService
    {
        Task<IEnumerable<Trabajo>> ObtenerTodosLosTrabajos();

        Task<Trabajo> ObtenerTrabajo(int codTrabajo);

        Task AñadirTrabajo(Trabajo trabajo);

        Task ActualizarTrabajo(Trabajo trabajo);

        Task EliminarTrabajo(int codTrabajo);

    }
}
