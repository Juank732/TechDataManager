using TechOil.Models;

namespace TechOil.Services
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> ObtenerTodosLosServicios();

        Task<Servicio> ObtenerServicio(int codServicio);

        Task<IEnumerable<Servicio>> ObtenerServiciosActivos();

        Task AñadirServicio(Servicio servicio);


        Task ActualizarServicio(Servicio servicio);

        Task EliminarServicio(int codServicio);
    }
}
