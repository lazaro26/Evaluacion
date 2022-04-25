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
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;

namespace acadecimico_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _alumnoService;
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger<AlumnoController> _logger;

        public AlumnoController(IAlumnoService alumnoService, IUsuarioService usuarioService)
        {
            this._alumnoService = alumnoService ?? throw new ArgumentNullException(nameof(alumnoService));
            this._usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        [Authorize]
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Alumno>>> listar(string nombre)
        {
            return (await _alumnoService.ConsultarAlumno(nombre)).ToList();
        }

        [Authorize]
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> RegistrarAlumno(AlumnoRequest obj)
        {
            var resut = await _alumnoService.RegistrarAlumno(obj);      
            return Ok(resut);
          
        }

        [Authorize]
        [HttpPost]
        [Route("registrarUsuario")]
        public async Task<IActionResult> RegistrarAlumnoUsuario(AlumnoUsuarioRequest obj)
        {
            var resut = await _usuarioService.RegistrarUsuario(obj);
            return Ok(resut);

        }


        [Authorize]
        [HttpPost]
        [Route("obtenerAlumno")]
        public async Task<ActionResult<IEnumerable<Alumno>>> listar(AtributosRequest obj)
        {
         
            return (await _alumnoService.ObtnerDatoAlumno(obj)).ToList();
        }

    }
}
