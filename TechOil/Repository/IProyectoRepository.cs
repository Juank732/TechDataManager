using TechOil.Models;

namespace TechOil.Repository
{
    public interface IProyectoRepository
    {
        Task<Proyecto> GetById(int codProyecto);

        Task<IEnumerable<Proyecto>> GetByState(int estado);
        Task<IEnumerable<Proyecto>> GetAll();

        Task Add(Proyecto entity);

        Task Update(Proyecto entity);

        Task Delete(int codProyecto);
    }
}
