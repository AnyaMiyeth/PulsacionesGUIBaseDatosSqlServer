using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Conexion
    {

        public string ConnectionString;
        public SqlConnection conexion;
        public Conexion()
        {
            conexion = new SqlConnection(ConnectionString);
            ConnectionString = @"Data Source=.;Initial Catalog=BDPulsacion;Integrated Security=True";
        }
    }
}
