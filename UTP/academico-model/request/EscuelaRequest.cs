using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace academico_model.request
{
    public  class EscuelaRequest
    {
        [Required(ErrorMessage = "Ingrese el campo Usuario")]
        public int idEscuela { get; set; }
    }
}
