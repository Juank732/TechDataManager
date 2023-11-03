using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechOil.Models;
using TechOil.Models.DTO;
using TechOil.Services;

namespace TechOil.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioService.ObtenerTodosLosUsuarios();

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet]
        [Authorize(Roles = "admin,consultor")]
        [Route("{codUsuario}")]
        public async Task<IActionResult> GetByCod(int codUsuario)
        {
            var usuario = await _usuarioService.ObtenerUsuario(codUsuario);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.contrasena);

            var nuevoUsuario = new Usuario
            {
                nombre = usuario.nombre,
                dni = usuario.dni,
                tipo = usuario.tipo,
                contrasena = hashedPassword
            };
            await _usuarioService.AñadirUsuario(nuevoUsuario);

            return CreatedAtAction("Get", new { id = usuario.codUsuario }, usuario);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{codUsuario}")]
        public async Task<IActionResult> Put(int codUsuario, UsuarioDTO usuario)
        {
            var _usuario = await _usuarioService.ObtenerUsuario(codUsuario);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.contrasena);

            if (_usuario == null)
            {
                return NotFound();
            }

            _usuario.codUsuario = _usuario.codUsuario;
            _usuario.nombre = usuario.nombre;
            _usuario.dni = usuario.dni;
            _usuario.tipo = usuario.tipo;
            _usuario.contrasena = hashedPassword;
            await _usuarioService.ActualizarUsuario(_usuario);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{codUsuario}")]
        public async Task<IActionResult> Delete(int codUsuario)
        {
            var usuario = await _usuarioService.ObtenerUsuario(codUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioService.EliminarUsuario(codUsuario);

            return Ok();
        }
    }
}
