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
    public class CicloController : ControllerBase
    {

        private readonly ICicloService _cicloService;
        private readonly ILogger<CicloController> _logger;

        public CicloController(ICicloService cicloService)
        {
            this._cicloService = cicloService ?? throw new ArgumentNullException(nameof(cicloService));
         
        }

        [Authorize]
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Ciclo>>> listar()
        {
            return (await _cicloService.ListarCiclo()).ToList();
        }


    }
}
