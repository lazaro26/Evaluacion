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
    public class NotaData : INotaData
    {
        private readonly string _connectionString;
        private readonly Populate _populate;

        public NotaData(IConfiguration configuration, Populate populate)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _populate = populate;
        }



        public async Task<Response> RegistrarNota(Nota obj)
        {
            Response response = new Response();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                await sql.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("usp_registrar_nota", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter Identidad = new SqlParameter("@IdNota", SqlDbType.Int);
                    Identidad.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(Identidad);
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", obj.idAlumno));                   
                    cmd.Parameters.Add(new SqlParameter("@idSemestre", obj.idSemestre));
                    cmd.Parameters.Add(new SqlParameter("@UsurioRegistro", obj.UsurioRegistro));

                    try
                    {
                        await cmd.ExecuteNonQueryAsync();
                        response.result = true;
                        response.id = Convert.ToInt32(cmd.Parameters["@IdNota"].Value);
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

        public async Task<Response> RegistrarNotaDetalle(NotaDetalle obj)
        {
            Response response = new Response();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_registrar_nota_detalle", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idNota", obj.idNota));
                    cmd.Parameters.Add(new SqlParameter("@IdCurso", obj.idCurso));
                    cmd.Parameters.Add(new SqlParameter("@Calificacion", obj.calificacion));

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


        public async Task<IEnumerable<Nota>> ConsultaNotaAlumno(Nota obj)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_consultar_nota_alumno", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", obj.idAlumno));
                    cmd.Parameters.Add(new SqlParameter("@idSemestre", obj.idSemestre));
                    var response = new List<Nota>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetNota(reader));
                        }
                    }
                    return response;
                }
            }
        }


    }
}
