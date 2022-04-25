using System;
using System.Collections.Generic;
using System.Text;

namespace academico_model.request
{
    public  class CursoRequest
    {

        public int idEscuela { get; set; }
        public int idCliclo { get; set; }
        public int IdAlumno { get; set; }
        public int idSemestre { get; set; }
    }
}
