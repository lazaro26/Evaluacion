using academico_model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace academico_data_intf
{
    public interface INotaData
    {

        Task<Response> RegistrarNota(Nota obj);
        Task<Response> RegistrarNotaDetalle(NotaDetalle obj);
        Task<IEnumerable<Nota>> ConsultaNotaAlumno(Nota obj);
    }
}
