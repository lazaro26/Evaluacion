using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using academico_model;
using academico_common;
using acadecimico_backend.Common;
using academico_service_intf;
using System.Threading.Tasks;
using academico_model.request;
using System.Linq;

namespace acadecimico_backend.Controllers
{
    [Route("api/identidad")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;


        public LoginController(IConfiguration configuration, ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _logger = logger;
            _usuarioService = usuarioService;
        }

            [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioRequest login)
        {
            try
            {
               var respuesta = await _usuarioService.ConsultarUsuario(login);

                if (respuesta.ToList().Count > 1)
                {
                    return BadRequest("Usuario/Contraseña incorrectos");
                }

                var token = GenerarToken(login);

                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Login: " + e.Message, e);
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, e.Message);
            }
        }



        private JwtSecurityToken GenerarToken(UsuarioRequest login)
        {
            string ValidIssuer = _configuration["ApiAuth:Issuer"];
            string ValidAudience = _configuration["ApiAuth:Audience"];
            SymmetricSecurityKey IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"]));

            //La fecha de expiracion sera el mismo dia a las 12 de la noche
            DateTime dtFechaExpiraToken;
            DateTime now = DateTime.Now;
            //dtFechaExpiraToken = new DateTime(now.Year, now.Month, now.Day, 21, 59, 59, 999);
             dtFechaExpiraToken = DateTime.UtcNow.AddSeconds(100000000);


            //Agregamos los claim nuestros
            var claims = new[]
            {
                new Claim(Constante.JWT_CLAIM_USUARIO, login.Usuario)
            };

            return new JwtSecurityToken
            (
                issuer: ValidIssuer,
                audience: ValidAudience,
                claims: claims,
                expires: dtFechaExpiraToken,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256)

            );
        }



    }
}
