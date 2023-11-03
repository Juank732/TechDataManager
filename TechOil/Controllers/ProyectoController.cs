using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Models.DTO;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProyectoController : ControllerBase
    {
        //Se almacena una instancia de la clase ProyectoService.
        private readonly ProyectoService _proyectoService;

        public ProyectoController(ProyectoService proyectoService)
        {
            _proyectoService = proyectoService;

        }
        //Método para devolver todos los proyectos existentes en la base de datos.
        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        public async Task<IActionResult> Get()
        {
            var proyectos = await _proyectoService.ObtenerTodosLosProyectos();

            if (proyectos == null)
            {
                return NotFound();
            }

            return Ok(proyectos);

        }
        //Método para buscar un proyecto en la base de datos mediante su código de identificación.
        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        [Route("{codProyecto}")]
        public async Task<IActionResult> GetbyCod(int codProyecto)
        {
            var proyecto = await _proyectoService.ObtenerProyecto(codProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }

            return Ok(proyecto);
        }

        //Método para filtrar los proyectos por su estado.
        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        [Route("filtrar/{estado}")]
        public async Task<IActionResult> GetByEstado(int estado)
        {
            var proyectos = await _proyectoService.ObtenerProyectoPorEstado(estado);

            //En caso de no encontrar proyectos con el estado requerido devuelve un 404;
            if (proyectos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(proyectos);
        }

        //Método para agregar un proyecto la base de datos.
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(Proyecto proyecto)
        {
            await _proyectoService.AñadirProyecto(proyecto);

            return CreatedAtAction("Get", new { id = proyecto.codProyecto }, proyecto);
        }

        //Método para actualizar un proyecto en la base de datos.
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{codProyecto}")]
        public async Task<IActionResult> Put(int codProyecto, ProyectoDTO proyecto)
        {
            var _proyecto = await _proyectoService.ObtenerProyecto(codProyecto);

            if (_proyecto == null)
            {
                return NotFound();
            }

            _proyecto.nombre = proyecto.nombre;
            _proyecto.direccion = proyecto.direccion;
            _proyecto.estado = proyecto.estado;
            await _proyectoService.ActualizarProyecto(_proyecto);

            return Ok();
        }

        //Método para eliminar un proyecto en la base de datos.
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{codProyecto}")]
        public async Task<IActionResult> Delete(int codProyecto)
        {
            var proyecto = await _proyectoService.ObtenerProyecto(codProyecto);

            if (proyecto == null)
            {
                return NotFound();
            }

            await _proyectoService.EliminarProyecto(codProyecto);

            return Ok();
        }

    }




}
