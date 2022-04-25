using academico_common;
using academico_data_intf;
using academico_model;
using academico_model.request;
using academico_service_intf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tecnologia.util.lib.Exceptions;

namespace academico_service_imp
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoData _alumnoData;

        public AlumnoService(IAlumnoData alumnoData)
        {
            _alumnoData = alumnoData;
        }


        public async Task<IEnumerable<Alumno>> ConsultarAlumno(string nombre)
        {
            try { 

            Alumno obj = new Alumno();
                obj.nombres = (nombre == null) ? "" : nombre;

            var response = await _alumnoData.ConsultarAlumno(obj);
            if (response == null)
                throw new NotFoundCustomException(Constante.MS_VALIDACION_NUMERO_ALUMNO);

                return response;

            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }


        public async Task<IEnumerable<Alumno>> ObtnerDatoAlumno(AtributosRequest obj)
        {
            try
            {

                Alumno alu = new Alumno();
                alu.idUsuario = obj.idUsuario;

                var response = await _alumnoData.ObtnerDatoAlumno(alu);
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_NUMERO_ALUMNO);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Response> RegistrarAlumno(AlumnoRequest obj)
        {
            Response response = new Response();
            try {


                Alumno Alum = new Alumno();
                Alum.numeroDocumento = obj.numeroDocumento;
                Alum.nombres = obj.nombres;
                Alum.apellidoPaterno = obj.apellidoPaterno;
                Alum.apellidoMaterno = obj.apellidoMaterno;
                Alum.idEscuela =  obj.idEscuela;

                var resul1 =  await _alumnoData.RegistrarAlumno(Alum);

                if (resul1.result == false)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_REGISTRO_ALUMNO);

             


                response = resul1;
            }
            catch (Exception ex)
            {
                response.result = false;
                response.messages = ex.Message;
            }

            return response;

        }
    }
}
