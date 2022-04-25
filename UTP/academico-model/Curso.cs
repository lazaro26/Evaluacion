using System;
using System.Collections.Generic;
using System.Text;

namespace academico_model
{
    public  class Curso
    {
        public int? idCurso { get; set; }
        public string codigoCurso { get; set; }
        public string ciclo { get; set; }
        public int? creditos { get; set; }
        public string nombreCurso { get; set; }
        public int? idEscuela { get; set; }
        public int? idCliclo { get; set; }
        public int? nota { get; set; }
        public int? evaluado { get; set; }
        public int? idAlumno { get; set; }
        public int? idSemestre { get; set; }
    }
}
