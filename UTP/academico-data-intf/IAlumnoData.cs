using academico_model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace academico_data_intf
{
    public interface IAlumnoData
    {
        Task<IEnumerable<Alumno>> ConsultarAlumno(Alumno obj);
        Task<Response> RegistrarAlumno(Alumno obj);
        Task<Response> RegistrarAlumnoUsuario(Alumno obj);
        Task<IEnumerable<Alumno>> ObtnerDatoAlumno(Alumno obj);
    }
}
