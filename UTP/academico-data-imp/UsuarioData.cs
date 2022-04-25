using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;
using academico_common;
using academico_data_intf;
using academico_data_imp.Funciones;
using academico_model;
using System.Data;

namespace academico_data_imp
{
    public class UsuarioData : IUsuarioData
    {
        private readonly string _connectionString;
        private readonly Populate _populate;

        public UsuarioData(IConfiguration configuration, Populate populate)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _populate = populate;
        }

        public async Task<IEnumerable<Usuario>> ConsultarUsuario(Usuario obj)
        {
         
                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ConsultarUsuario", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@usuario", obj.usuario));
                        cmd.Parameters.Add(new SqlParameter("@clave", obj.clave));
                        var response = new List<Usuario>();
                        await sql.OpenAsync();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(_populate.SetUsuario(reader));
                            }
                        }
                        return response;
                    }
                }         
           
        }



        public async Task<Response> RegistrarUsuario(Usuario obj)
        {
            Response response = new Response();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                await sql.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("usp_registrar_usuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter Identidad = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    Identidad.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(Identidad);                    
                    cmd.Parameters.Add(new SqlParameter("@IdTipo", obj.idTipo));
                    cmd.Parameters.Add(new SqlParameter("@Usuario", obj.usuario));
                    cmd.Parameters.Add(new SqlParameter("@Clave", obj.clave));

                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
                        response.result = true;
                        response.id = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value);
                    }
                    catch (Exception e)
                    {
                        response.result = false;
                        response.messages = e.Message;
                    }
                    finally
                    {
                        sql.Close();
                    }
                }
            }
            return response;
        }



      

    }

   
}
