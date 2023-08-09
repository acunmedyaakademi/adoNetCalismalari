using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoNetClassYapilari
{
    public class DB
    {
        public static SqlConnection conn()
        {
            return new SqlConnection("Server=.\\SQLEXPRESS;Database=Northwind; Integrated Security=True; TrustServerCertificate=Yes");

        }
    }
}

