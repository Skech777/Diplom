using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Diploma.Classes
{
    public static class SQLConnectionInfo
    {

        static public String StringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\kloch\source\repos\Diploma\Diploma\Database1.mdf;Integrated Security=True";
        static public SqlConnection @SqlConnection;
        static public SqlCommand @SqlCommand;

        static SQLConnectionInfo()
        {
            SqlConnection = new SqlConnection(StringConnection);            
        }
    }
}
