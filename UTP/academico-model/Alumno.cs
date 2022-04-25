using System;

namespace academico_model
{
    public class Alumno
    {
        public int idAlumno { get; set; }
        public string codigo { get; set; }
        public string numeroDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public int idUsuario { get; set; }
        public int idEscuela { get; set; }
        public string nombreEscuela { get; set; }

    }
}
