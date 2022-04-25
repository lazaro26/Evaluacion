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
    public class SemestreService : ISemestreService
    {
        private readonly ISemestreData _semestreData;

        public SemestreService(ISemestreData semestreData)
        {
            _semestreData = semestreData;
        }

        public async Task<IEnumerable<Semestre>> ListarSemestre()
        {
            try
            {
                var response = await _semestreData.ListarSemestre();
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_SEMESTRE);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Semestre>> ListarSemestreAlumno(int idAlumno)
        {
            try
            {
                var response = await _semestreData.ListarSemestreAlumno(idAlumno);
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_SEMESTRE);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
