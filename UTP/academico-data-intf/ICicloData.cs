using academico_model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace academico_data_intf
{
    public interface ICicloData
    {
        Task<IEnumerable<Ciclo>> ListarCiclo();
    }
}
