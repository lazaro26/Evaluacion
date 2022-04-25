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
     public  class SemestreData : ISemestreData
    {
        private readonly string _connectionString;
        private readonly Populate _populate;

        public SemestreData(IConfiguration configuration, Populate populate)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _populate = populate;
        }


        public async Task<IEnumerable<Semestre>> ListarSemestre()
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_listar_semestre", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Semestre>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetSemestre(reader));
                        }
                    }
                    return response;
                }
            }
        }


        public async Task<IEnumerable<Semestre>> ListarSemestreAlumno(int idAlumno)
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_lista_semestre_alumno", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@IdAlumno", idAlumno));

                    var response = new List<Semestre>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetSemestre(reader));
                        }
                    }
                    return response;
                }
            }
        }

    }
}
