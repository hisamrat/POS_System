using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.DataAccess
{
   public class DatabaseConnections
    {
        public SqlConnection con;
        public void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["POSConn"].ToString();
            con = new SqlConnection(constring);
        }
    }
}
