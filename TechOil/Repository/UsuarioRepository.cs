using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiContext _dbContext;

        public UsuarioRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _dbContext.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> GetById(int codUsuario)
        {
            var filtrarUsuario = await _dbContext.Usuarios.FirstOrDefaultAsync(s => s.codUsuario == codUsuario);

            return filtrarUsuario;
        }

        public async Task Add(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int codUsuario)
        {
            var usuario = await GetById(codUsuario);

            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
