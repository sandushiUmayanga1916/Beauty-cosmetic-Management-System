using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Beauty_Cosmetics
{
    class ClassEmployees
    {
        DBConnect con = new DBConnect();
        //create a function to insert Employee

        public bool insertEmployee(string eId, string eName, string email, string contact, string gender,string date,string address,string sal)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_employees('employee_id','employee_name','email_address','contact_no','gender','date','address','salary' ) VALUES ('@eId','@eName','@email','@contact','@gender','@date','@address','@sal') ", con.GetConnection);
            //@eId,@eName,@email,@contact,@gender,@date,@address,@salary
            cmd.Parameters.Add("@eId", SqlDbType.VarChar).Value = eId;
            cmd.Parameters.Add("@eName", SqlDbType.VarChar).Value = eName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@salary", SqlDbType.VarChar).Value = sal;
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

        public DataTable getEmployees(SqlCommand cmd)
        {
            cmd.Connection = con.GetConnection;
            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adpter.Fill(table);
            return table;
        }

        //create a update function for employee edit

        public bool updateEmployees(string eId, string eName, string email, string contact, string gender, string date, string address, string sal)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_employees SET 'employee_id'=@eId,'employee_name' = @eName,'email_address'=@email,'contact_no'=@contact,'gender='@gender,'date'=@date,'address'=@address,'sal'=@sal WHERE employee_id=@eId", con.GetConnection);
            //@eId,@eName,@email,@contact,@gender,@date,@address,@salary
            cmd.Parameters.Add("@eId", SqlDbType.VarChar).Value = eId;
            cmd.Parameters.Add("@eName", SqlDbType.VarChar).Value = eName;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@salary", SqlDbType.VarChar).Value = sal;
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

        //create a function to delete a employee
        //we only need employee id

        public bool deleteEmployee(string eId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_employees WHERE 'employee_id'=@eId", con.GetConnection);
            cmd.Parameters.Add("@eId", SqlDbType.VarChar).Value = eId;
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
