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
    public class NotaController : ControllerBase
    {

        private readonly INotaService _notaService;
        private readonly ILogger<NotaController> _logger;

        public NotaController(INotaService notaService)
        {
            this._notaService = notaService ?? throw new ArgumentNullException(nameof(notaService));
 
        }


        [Authorize]
        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> RegistrarAlumno(NotaRequest obj)
        {
            var resut = await _notaService.RegistrarNota(obj);
            return Ok(resut);

        }



    }
}
