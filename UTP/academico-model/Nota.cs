using System;
using System.Collections.Generic;
using System.Text;

namespace academico_model
{
    public class Nota
    {
        public int? idNota { get; set; }
        public int? idAlumno { get; set; }
        public int? idSemestre { get; set; }
        public string UsurioRegistro { get; set; }
        public IEnumerable<NotaDetalle> notaDetalle { get; set; }
       

    }
}
