using TechOil.Models;

namespace TechOil.Services
{
    public interface IServicioService
    {
        IEnumerable<Servicio> ObtenerTodosLosServicios();

        Task<Servicio> ObtenerServicio(int codServicio);

        public IEnumerable<Servicio> ObtenerServiciosActivos(); 

        Task AñadirServicio(Servicio servicio);


        Task ActualizarServicio(Servicio servicio); 

        Task EliminarServicio(int codServicio);
    }
}
