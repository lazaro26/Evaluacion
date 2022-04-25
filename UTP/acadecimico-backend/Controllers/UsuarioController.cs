using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IConfiguration configuration, ILogger<UsuarioController> logger , IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _logger = logger;
            _usuarioService = usuarioService;
        }


        [Authorize]
        [HttpPost]
        [Route("consultarUsuario")]
        public async Task<IActionResult> ConsultarUsuario(UsuarioRequest obj)
        {
            var resut = await _usuarioService.ConsultarUsuario(obj);
            return Ok(resut);

        }





    }
}
