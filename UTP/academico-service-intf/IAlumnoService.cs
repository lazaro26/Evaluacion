using academico_model;
using academico_model.request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace academico_service_intf
{
    public interface IAlumnoService
    {
        Task<IEnumerable<Alumno>> ConsultarAlumno(string nombre);
        Task<Response> RegistrarAlumno(AlumnoRequest obj);
        Task<IEnumerable<Alumno>> ObtnerDatoAlumno(AtributosRequest obj);
    }
}
