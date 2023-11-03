using TechOil.Models;

namespace TechOil.Repository
{
    public interface IServicioRepository
    {
        Task<Servicio> GetById(int codServicio);

        Task<IEnumerable<Servicio>> GetAll();

        Task<IEnumerable<Servicio>> GetActive();

        Task Add(Servicio entity);

        Task Update(Servicio entity);

        Task Delete(int codServicio);
    }
}
