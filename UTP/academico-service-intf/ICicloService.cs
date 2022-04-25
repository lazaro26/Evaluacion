using academico_model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace academico_service_intf
{
    public interface ICicloService
    {
        Task<IEnumerable<Ciclo>> ListarCiclo();
    }
}
