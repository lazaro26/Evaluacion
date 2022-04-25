using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace academico_model.request
{
    public class NotaRequest
    {
   
        public int idNota { get; set; }

        [Required(ErrorMessage = "Ingrese el campo numero idAlumno")]
        public int idAlumno { get; set; }

        [Required(ErrorMessage = "Ingrese el campo numero idSemestre")]
        public int idSemestre { get; set; }

        public string UsurioRegistro { get; set; }

        [Required(ErrorMessage = "Ingrese el campo numero documento")]
        public IEnumerable<NotaDetalle> notaDetalle { get; set; }

       

    }
}
