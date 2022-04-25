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
    public class CursoService :ICursoService
    {

        private readonly ICursoData _cursoData;

        public CursoService(ICursoData cursoData)
        {
            _cursoData = cursoData;
        }


        public async Task<IEnumerable<Curso>> ListarCurso(CursoRequest obj)
        {
            try
            {
                Curso esc = new Curso();
                esc.idEscuela = obj.idEscuela;
                esc.idCliclo = obj.idCliclo;
                esc.idAlumno = obj.IdAlumno;
                esc.idSemestre = obj.idSemestre;

                var response = await _cursoData.ListarCurso(esc);
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_ESCUELA);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Curso>> ListarCursoAlumno(CursoRequest obj)
        {
            try
            {
                Curso esc = new Curso();
                esc.idEscuela = obj.idEscuela;
                esc.idCliclo = obj.idCliclo;
                esc.idAlumno = obj.IdAlumno;
                esc.idSemestre = obj.idSemestre;

                var response = await _cursoData.ListarCursoAlumno(esc);
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_ESCUELA);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        




    }
}
