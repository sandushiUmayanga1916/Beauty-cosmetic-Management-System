using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Beauty_Cosmetics
{
    /*
     * in this class create the connection between application and msSQL database
     */
    class DBConnect
    {
        //to create connection
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-LCO0SD50;Initial Catalog=cosmetics;Integrated Security=True;Pooling=False");
        //to get connection

        public SqlConnection GetConnection
        {
            get
            {
                return con;
            }
        }

        //create function to open connection
        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        //create function to close connection
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}
