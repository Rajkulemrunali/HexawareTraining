using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PayXpert.DataAccessLayer
{
    public class DBUtil
    {
        public static SqlConnection getDBConnection()
        {
            //step 1 - Establish Connection
            try
            {
                SqlConnection conn;
                string connectionString = "Data Source=LAPTOP-2G5S808O\\SQLEXPRESS; Initial Catalog=Payxpert; Integrated Security=True";
                conn = new SqlConnection(connectionString);
                //conn.Open();
                Console.WriteLine("Database Connected SuccessFully");
                return conn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }



        }
    }
}
