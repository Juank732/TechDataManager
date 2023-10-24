using TechOil.Models;

namespace TechOil.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetById(int codUsuario);

        IEnumerable<Usuario> GetAll();

        Task Add(Usuario entity);

        Task Update(Usuario entity);

        Task Delete(int codUsuario);
    }
}
