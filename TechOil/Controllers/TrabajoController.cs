using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Models.DTO;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrabajoController : ControllerBase
    {
        private readonly TrabajoService _trabajoService;

        public TrabajoController(TrabajoService trabajoService)
        {
            _trabajoService = trabajoService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        public async Task<IActionResult> Get()
        {
            var trabajos = await _trabajoService.ObtenerTodosLosTrabajos();

            if (trabajos == null)
            {
                return NotFound();
            }
            return Ok(trabajos);
        }

        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        [Route("{codTrabajo}")]
        public async Task<IActionResult> GetByCod(int codTrabajo)
        {
            var trabajo = await _trabajoService.ObtenerTrabajo(codTrabajo);

            if (trabajo == null)
            {
                return NotFound();
            }
            return Ok(trabajo);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(Trabajo trabajo)
        {
            await _trabajoService.AñadirTrabajo(trabajo);

            return CreatedAtAction("Get", new { id = trabajo.codTrabajo }, trabajo);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{codTrabajo}")]
        public async Task<IActionResult> Put(int codTrabajo, TrabajoDTO trabajo)
        {
            var _trabajo = await _trabajoService.ObtenerTrabajo(codTrabajo);

            if (_trabajo == null)
            {
                return NotFound();
            }

            _trabajo.fecha = trabajo.fecha;
            _trabajo.cantHoras = trabajo.cantHoras;
            _trabajo.valorHora = trabajo.valorHora;
            _trabajo.costo = trabajo.costo;
            _trabajo.codProyecto = trabajo.codProyecto;
            _trabajo.codServicio = trabajo.codServicio;
            await _trabajoService.ActualizarTrabajo(_trabajo);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{codTrabajo}")]
        public async Task<IActionResult> Delete(int codTrabajo)
        {
            var trabajo = await _trabajoService.ObtenerTrabajo(codTrabajo);

            if (trabajo == null)
            {
                return NotFound();
            }

            await _trabajoService.EliminarTrabajo(codTrabajo);

            return Ok();
        }
    }
}
