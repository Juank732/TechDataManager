using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repository
{
    public class TrabajoRepository : ITrabajoRepository
    {
        private readonly ApiContext _dbContext;

        public TrabajoRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Trabajo>> GetAll()
        {
            var trabajos = _dbContext.Trabajos.ToList();

            return trabajos;
        }


        public async Task<Trabajo> GetById(int codTrabajo)
        {
            return await _dbContext.Trabajos.FirstOrDefaultAsync(s => s.codTrabajo == codTrabajo);
        }

        public async Task Add(Trabajo trabajo)
        {
            _dbContext.Trabajos.Add(trabajo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Trabajo trabajo)
        {
            _dbContext.Trabajos.Update(trabajo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int codTrabajo)
        {
            var usuario = await GetById(codTrabajo);

            if (usuario != null)
            {
                _dbContext.Trabajos.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
