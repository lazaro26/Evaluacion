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
    public class EscuelaService : IEscuelaService
    {

        private readonly IEscuelaData _escuelaData;

        public EscuelaService(IEscuelaData escuelaData)
        {
            _escuelaData = escuelaData;
        }

        public async Task<IEnumerable<Escuela>> ListarEscuela()
        {
            try
            {
                var response = await _escuelaData.ListarEscuela();
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_CICLO);

                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
