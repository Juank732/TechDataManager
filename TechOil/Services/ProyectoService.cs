using Abp.Extensions;
using TechOil.DataAccess;
using TechOil.Models;
using TechOil.Repository;

namespace TechOil.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IProyectoRepository _proyectoRepository;

        public ProyectoService(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }

        public virtual IEnumerable<Proyecto> ObtenerTodosLosProyectos()
        {
            return _proyectoRepository.GetAll();
        }


        public async Task<Proyecto> ObtenerProyecto(int codProyecto)
        {
            return await _proyectoRepository.GetById(codProyecto);
        }

        public IEnumerable<Proyecto> ObtenerProyectoPorEstado(int estado)
        {
            return _proyectoRepository.GetByState(estado);
        }

        public async Task AñadirProyecto(Proyecto proyecto)
        {
            await _proyectoRepository.Add(proyecto);
        }
  
        public async Task ActualizarProyecto(Proyecto proyecto)
        {
            await _proyectoRepository.Update(proyecto);
        }

        public async Task EliminarProyecto(int codProyecto)
        {
            await _proyectoRepository.Delete(codProyecto);
        }
    }
}
