using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<Servicio>> ObtenerTodosLosServicios()
        {
            return await _servicioRepository.GetAll();
        }


        public async Task<Servicio> ObtenerServicio(int codServicio)
        {
            return await _servicioRepository.GetById(codServicio);
        }

        public async Task<IEnumerable<Servicio>> ObtenerServiciosActivos()
        {
            return await _servicioRepository.GetActive();
        }
        public async Task AñadirServicio(Servicio servicio)
        {
            await _servicioRepository.Add(servicio);
        }

        public async Task ActualizarServicio(Servicio servicio)
        {
            await _servicioRepository.Update(servicio);
        }

        public async Task EliminarServicio(int codServicio)
        {
            await _servicioRepository.Delete(codServicio);
        }
    }
}
