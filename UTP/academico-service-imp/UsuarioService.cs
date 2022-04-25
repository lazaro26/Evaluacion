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
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioData _usuarioData;
        private readonly IAlumnoData _alumnoData;


        public UsuarioService(IUsuarioData usuarioData , IAlumnoData alumnoData)
        {
            _usuarioData = usuarioData;
            _alumnoData = alumnoData;   
        }


        public async Task<IEnumerable<Usuario>> ConsultarUsuario(UsuarioRequest obj) {
            try
            {
                Usuario usuario = new Usuario();
                usuario.usuario = obj.Usuario;
                usuario.clave = obj.Password;

                var response = await _usuarioData.ConsultarUsuario(usuario);
                if (response == null)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_USUARIO);

                return response;
            }
            catch (Exception ex) 
            {
                throw ex;
            }          
        }

        public async Task<Response> RegistrarUsuario(AlumnoUsuarioRequest obj)
        {
            Response response = new Response();
            try
            {


                Usuario Usu = new Usuario();
                Usu.idTipo =  (int)VariablesGlobales.TablaTipoUsuario.Alumno;
                Usu.usuario = obj.Usuario;
                Usu.clave = obj.Password;


                var resul1 = await _usuarioData.RegistrarUsuario(Usu);

                if (resul1.result == false)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_REGISTRO_USUARIO);

                Alumno Alu = new Alumno();
                Alu.idAlumno = obj.alumno.idAlumno;
                Alu.idUsuario = resul1.id;

                var resul2 = await _alumnoData.RegistrarAlumnoUsuario(Alu);

                if (resul2.result == false)
                    throw new NotFoundCustomException(Constante.MS_VALIDACION_REGISTRO_USUARIO);


                response = resul2;
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
