using Microsoft.EntityFrameworkCore;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Repository
{
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly ApiContext _dbContext;

        public ProyectoRepository(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Proyecto>> GetAll()
        {
            var proyectos = _dbContext.Proyectos.ToList();
            return proyectos;
        }

        public async Task<IEnumerable<Proyecto>> GetByState(int estado)
        {
            var proyectos = _dbContext.Proyectos.Where(p => p.estado == estado);
            return proyectos;
        }

        public async Task<Proyecto> GetById(int codProyecto)
        {
            return await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.codProyecto == codProyecto);
        }


        public async Task Add(Proyecto proyecto)
        {
            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Proyecto proyecto)
        {
            _dbContext.Proyectos.Update(proyecto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int codProyecto)
        {
            var proyecto = await GetById(codProyecto);

            if (proyecto != null)
            {
                _dbContext.Proyectos.Remove(proyecto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
