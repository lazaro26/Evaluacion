using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace academico_model.request
{
    public class AlumnoRequest
    {

        [Required(ErrorMessage = "Ingrese el campo numero documento")]
        public string numeroDocumento { get; set; }

        [Required(ErrorMessage = "Ingrese el campo nombres")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Ingrese el campo apellido paterno")]
        public string apellidoPaterno { get; set; }

        [Required(ErrorMessage = "Ingrese el campo apellido materno")]
        public string apellidoMaterno { get; set; }

        [Required(ErrorMessage = "Ingrese el campo idEscuela")]
        public int  idEscuela { get; set; }


    }
}
