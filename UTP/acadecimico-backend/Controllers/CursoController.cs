using Microsoft.AspNetCore.Mvc;
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
    public class CursoController : ControllerBase
    {

        private readonly ICursoService _cursoService;
        private readonly ILogger<CursoController> _logger;

        public CursoController(ICursoService cursoService)
        {
            this._cursoService = cursoService ?? throw new ArgumentNullException(nameof(cursoService));

        }
             

        [Authorize]
        [HttpPost]
        [Route("listar")]
        public async Task<IActionResult> ListarCurso(CursoRequest obj)
        {
            var resut = (await _cursoService.ListarCurso(obj)).ToList();
            return Ok(resut);

        }

        [Authorize]
        [HttpPost]
        [Route("listarCursosAlumno")]
        public async Task<IActionResult> RegistrarAlumnoUsuario(CursoRequest obj)
        {
            var resut = (await _cursoService.ListarCursoAlumno(obj)).ToList();
            return Ok(resut);

        }

    }
}

