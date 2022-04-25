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
    public  class CicloService : ICicloService
    {
        private readonly ICicloData _cicloData;

        public CicloService(ICicloData cicloData)
        {
            _cicloData = cicloData;
        }


        public async Task<IEnumerable<Ciclo>> ListarCiclo()
        {
            try
            { 
                var response = await _cicloData.ListarCiclo();
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
