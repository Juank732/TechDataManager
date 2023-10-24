using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioRepository.GetAll();
        }


        public async Task<Usuario> ObtenerUsuario(int codUsuario)
        {
            return await _usuarioRepository.GetById(codUsuario);
        }


        public async Task AñadirUsuario(Usuario usuario)
        {
            await _usuarioRepository.Add(usuario);
        }
        public async Task ActualizarUsuario(Usuario usuario)
        {
            await _usuarioRepository.Update(usuario);
        }


        public async Task EliminarUsuario(int codUsuario)
        {
            await _usuarioRepository.Delete(codUsuario);
        }
    }
}
