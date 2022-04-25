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

namespace academico_data_imp
{
    public class AlumnoData : IAlumnoData
    {
        private readonly string _connectionString;
        private readonly Populate _populate;

        public AlumnoData(IConfiguration configuration, Populate populate)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _populate = populate;
        }


        public async Task<IEnumerable<Alumno>> ConsultarAlumno(Alumno obj)
        {
            
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_listaAlumnos", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nombres", obj.nombres));
                    var response = new List<Alumno>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetAlumno(reader));
                        }
                    }
                    return response;
                }
            }
        }

        public async Task<Response> RegistrarAlumno(Alumno obj)
        {
            Response response = new Response();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_registrar_alumno", sql ))
                {      
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@NumeroDocumento", obj.numeroDocumento));
                    cmd.Parameters.Add(new SqlParameter("@Nombres", obj.nombres));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", obj.apellidoPaterno));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", obj.apellidoMaterno));
                    cmd.Parameters.Add(new SqlParameter("@idEscuela", obj.idEscuela));

                    try {
                        await sql.OpenAsync();
                        object id = await cmd.ExecuteScalarAsync();
                        response.result = true;                   
                    }
                    catch (Exception e) {
                        response.result = false;
                        response.messages = e.Message;
                    }
                    finally{
                        sql.Close();
                    }
                }               
            }
            return response;
        }



        public async Task<Response> RegistrarAlumnoUsuario(Alumno obj)
        {
            Response response = new Response();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_registrar_alumno_usuario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", obj.idAlumno));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", obj.idUsuario));
                    

                    try
                    {
                        await sql.OpenAsync();
                        object id = await cmd.ExecuteScalarAsync();
                        response.result = true;
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


        public async Task<IEnumerable<Alumno>> ObtnerDatoAlumno(Alumno obj)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_obtener_dato_alumno", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdUsuario", obj.idUsuario));
                    var response = new List<Alumno>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetAlumno(reader));
                        }
                    }
                    return response;
                }
            }
        }

    }
    }
