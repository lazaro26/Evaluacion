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
    public class CursoData : ICursoData
    {
        private readonly string _connectionString;
        private readonly Populate _populate;

        public CursoData(IConfiguration configuration, Populate populate)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _populate = populate;
        }


        public async Task<IEnumerable<Curso>> ListarCurso( Curso obj)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_lista_curso_escuela", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idEscuela", obj.idEscuela));
                    cmd.Parameters.Add(new SqlParameter("@IdCliclo", obj.idCliclo));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", obj.idAlumno));
                    cmd.Parameters.Add(new SqlParameter("@idSemestre", obj.idSemestre));
                    var response = new List<Curso>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetCurso(reader));
                        }
                    }
                    return response;
                }
            }
        }


        public async Task<IEnumerable<Curso>> ListarCursoAlumno(Curso obj)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_lista_curso_escuela_alumno", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idEscuela", obj.idEscuela));
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", obj.idAlumno));
                    cmd.Parameters.Add(new SqlParameter("@idSemestre", obj.idSemestre));
                    var response = new List<Curso>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetCurso(reader));
                        }
                    }
                    return response;
                }
            }
        }


    }
}
