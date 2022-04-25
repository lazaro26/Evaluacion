using academico_common;
using academico_data_intf;
using academico_model;
using academico_model.request;
using academico_service_intf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tecnologia.util.lib.Exceptions;

namespace academico_service_imp
{
    public class NotaService : INotaService
    {

        private readonly INotaData _notaData;

        public NotaService(INotaData notaData)
        {
            _notaData = notaData;
        }


        public async Task<Response> RegistrarNota(NotaRequest obj)
        {
            Response response = new Response();
            try
            {
                Nota not = new Nota();
                not.idAlumno = obj.idAlumno;
                not.idSemestre = obj.idSemestre;
                not.UsurioRegistro = "JORGE";

                var Notas = await _notaData.ConsultaNotaAlumno(not);

                

                if (Notas.ToList().Count > 0)
                    throw new NotFoundCustomException(Constante.MS_REGISTRO_CONSULTA_NOTA);

                var registro = await _notaData.RegistrarNota(not);

                if(registro.result == false)
                    throw new NotFoundCustomException(Constante.MS_REGISTRO_REGISTRO_NOTA_VALIDAR);
                
                foreach (var item in obj.notaDetalle)
                {
                    NotaDetalle det = new NotaDetalle();
                    det.idNota = registro.id;
                    det.idCurso = item.idCurso;
                    det.calificacion = item.calificacion;

                    var detalleRegistro = await _notaData.RegistrarNotaDetalle(det);
                    if (detalleRegistro.result == false)
                        throw new NotFoundCustomException(Constante.MS_REGISTRO_REGISTRO_NOTA_VALIDAR);

                }

                response.result = true;
                response.messages = Constante.MS_REGISTRO_EXITOSO;

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