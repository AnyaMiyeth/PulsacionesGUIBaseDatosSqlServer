using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CadenaConexion
    {
        public string stringConnection{ get; set; }
        public CadenaConexion()
        {
            stringConnection = @"Data Source=.;Initial Catalog=BDPulsacion;Integrated Security=True";
        }
    }
}
