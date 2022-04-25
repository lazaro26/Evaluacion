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
    public class CicloData : ICicloData
    {

        private readonly string _connectionString;
        private readonly Populate _populate;

        public CicloData(IConfiguration configuration, Populate populate)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
            _populate = populate;
        }


        public async Task<IEnumerable<Ciclo>> ListarCiclo()
        {

            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_listar_ciclo", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Ciclo>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(_populate.SetCliclo(reader));
                        }
                    }
                    return response;
                }
            }
        }


    }
}
