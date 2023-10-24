using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TechOil.DataAccess;
using TechOil.Models;

namespace TechOil.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ApiContext _dbContext;


        public AuthController(ApiContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Verificar si las credenciales ingresadas son correctas.
            // Si las credenciales son válidas, genera un token JWT.
            if (ValidarCredenciales(model))
            {
                var token = CrearTokenJWT(model);

                return Ok(new { token });
            }


            return Unauthorized("Credenciales incorrectas");
        }

        private bool ValidarCredenciales(LoginModel model)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.codUsuario == model.codUsuario);

            //Verifica si la contraseña ingresada coincide con la contraseña encriptada en la base de datos.
			//------------------Desencripta la contraseña en DB----------------------
            if(usuario != null && BCrypt.Net.BCrypt.Verify(model.contrasena, usuario.contrasena))
            {
                return true;
            }

            return false;
        }

        private string CrearTokenJWT(LoginModel model)
        {

            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.codUsuario == model.codUsuario);

            if(usuario != null) { 

            //Esta lista contiene la información de identidad del usuario ingresado.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, model.codUsuario.ToString()), 
                new Claim(ClaimTypes.Name, model.codUsuario.ToString()), 
                new Claim(ClaimTypes.Role, usuario.tipo == 1 ? "admin" : "consultor")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bd1a1ccf8095037f361a4d351e7c0de65f0776bfc2f478ea8d312c763bb6caca"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Define la duración del token
                signingCredentials: creds
            );

            //Se retorna el token generado
            return new JwtSecurityTokenHandler().WriteToken(token);
            };

            return null;

            
        }
    }

}
