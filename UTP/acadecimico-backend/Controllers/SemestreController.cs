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
    public class SemestreController : ControllerBase
    {
        private readonly ISemestreService _semestreService;
        private readonly ILogger<SemestreController> _logger;

        public SemestreController(ISemestreService semestreService)
        {
            this._semestreService = semestreService ?? throw new ArgumentNullException(nameof(semestreService));

        }

        [Authorize]
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Semestre>>> listar()
        {
            return (await _semestreService.ListarSemestre()).ToList();
        }

        [Authorize]
        [HttpGet]
        [Route("listarSemestreAlumno")]
        public async Task<ActionResult<IEnumerable<Semestre>>> listar(int idAlumno)
        {
            return (await _semestreService.ListarSemestreAlumno(idAlumno)).ToList();
        }


    }
}
