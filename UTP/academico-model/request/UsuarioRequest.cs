using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace academico_model.request
{
    public class UsuarioRequest
    {


        [Required(ErrorMessage = "Ingrese el campo Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese el campo Password")]
        public string Password { get; set; }

        
    }
}
