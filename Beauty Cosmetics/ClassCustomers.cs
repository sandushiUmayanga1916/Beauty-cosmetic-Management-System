using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Beauty_Cosmetics
{
    class ClassCustomers
    {
        DBConnect con = new DBConnect();
        //create a function to insert customers

        public bool insetCustomers(string cId, string cName, string email, string contact, string address)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_customers('customer_id','customer_name','email_address','contact_no','address' ) VALUES ('@cId','@cName','@email','@contact','@address') ",con.GetConnection);
            //@cId,@cName,@email,@contact,@address
            cmd.Parameters.Add("@cId", SqlDbType.VarChar).Value = cId;
            cmd.Parameters.Add("@cName", SqlDbType.VarChar).Value = cName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            con.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }

        //create a function to get employee list

        public DataTable getCustomers(SqlCommand cmd)
        {
            cmd.Connection = con.GetConnection;
            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adpter.Fill(table);
            return table;
        }

        //create a update function for customer edit

        public bool updateCustomer(string cId, string cName, string email, string contact, string address)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_customer SET 'customer_id'=@cId,'customer_name' = @cName,'email_address'=@email,'contact_no'=@contact,'address'=@address WHERE customer_id=@cId", con.GetConnection);
            //@cId,@cName,@email,@contact,@address
            cmd.Parameters.Add("@cId", SqlDbType.VarChar).Value = cId;
            cmd.Parameters.Add("@cName", SqlDbType.VarChar).Value = cName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            con.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }

        //create a function to delete a customers
        //we only need customer id

        public bool deleteCustomer(string cId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_customers WHERE 'customer_id'=@cId", con.GetConnection);
            cmd.Parameters.Add("@cId", SqlDbType.VarChar).Value = cId;
            con.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }
    }
}
