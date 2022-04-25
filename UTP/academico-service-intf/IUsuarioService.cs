using academico_model;
using academico_model.request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace academico_service_intf
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ConsultarUsuario(UsuarioRequest obj);
        Task<Response> RegistrarUsuario(AlumnoUsuarioRequest obj);
    }
}
