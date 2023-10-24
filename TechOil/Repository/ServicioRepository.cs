using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repository
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly ApiContext _dbContext;

        public ServicioRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Servicio> GetAll()
        {
            var usuarios = _dbContext.Servicios.ToList();
            return usuarios;
        }

        public IEnumerable<Servicio> GetActive()
        {
            return _dbContext.Servicios.Where(s => s.estado == true);
            
        }

        public async Task<Servicio> GetById(int codServicio)
        {
            return await _dbContext.Servicios.FirstOrDefaultAsync(s => s.codServicio == codServicio);
        }

        public async Task Add(Servicio servicio)
        {
            _dbContext.Servicios.Add(servicio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Servicio servicio)
        {
            _dbContext.Servicios.Update(servicio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int codServicio)
        {
            var usuario = await GetById(codServicio);

            if(usuario != null)
            {
                _dbContext.Servicios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
