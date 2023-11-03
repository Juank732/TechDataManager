using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class TrabajoService : ITrabajoService
    {
        private readonly ITrabajoRepository _trabajoRepository;

        public TrabajoService(ITrabajoRepository trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        public async Task<IEnumerable<Trabajo>> ObtenerTodosLosTrabajos()
        {
            return await _trabajoRepository.GetAll();
        }


        public async Task<Trabajo> ObtenerTrabajo(int codTrabajo)
        {
            return await _trabajoRepository.GetById(codTrabajo);
        }

        public async Task AñadirTrabajo(Trabajo trabajo)
        {
            await _trabajoRepository.Add(trabajo);
        }

        public async Task ActualizarTrabajo(Trabajo trabajo)
        {
            await _trabajoRepository.Update(trabajo);
        }

        public async Task EliminarTrabajo(int codTrabajo)
        {
            await _trabajoRepository.Delete(codTrabajo);
        }
    }
}
