using TechOil.Models;

namespace TechOil.Repository
{
    public interface ITrabajoRepository
    {
        Task<Trabajo> GetById(int codTrabajo);

        IEnumerable<Trabajo> GetAll();

        Task Add(Trabajo entity);

        Task Update(Trabajo entity);

        Task Delete(int codTrabajo);
    }
}
