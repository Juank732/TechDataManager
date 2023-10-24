using TechOil.Models;

namespace TechOil.Services
{
    public interface IUsuarioService
    {

        IEnumerable<Usuario> ObtenerTodosLosUsuarios();  

        Task<Usuario> ObtenerUsuario(int codUsuario);

     
        Task AñadirUsuario(Usuario usuario);
  

        Task ActualizarUsuario(Usuario usuario); 

        Task EliminarUsuario(int codUsuario);
    }
}
