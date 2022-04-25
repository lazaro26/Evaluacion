using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace tecnologia.util.lib
{
    public class TransactionBase
    {
        public SqlConnection connection { get; set; }
        public SqlTransaction transaction { get; set; }
    }
}
