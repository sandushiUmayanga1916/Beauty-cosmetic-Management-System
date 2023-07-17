using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Beauty_Cosmetics
{
    class ClassBill
    {
        DBConnect con = new DBConnect();
        //create a function to insert Bill
        public bool insetBill(string bId, string date, string cName, string pName, float price,float qty, float tot, float dis, float gTot)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_bill('bill_id','date','customer_name','product_name','price','quantity','total','discount','grand_total' ) VALUES ('@bId','@date','@cName','@pName','@price','@qty','@tot','@dis','@gTot') ", con.GetConnection);
            //@bId,@date,@cName,@pName,@price,@qty,@tot,@dis,@gTot
            cmd.Parameters.Add("@bId", SqlDbType.VarChar).Value = bId;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@cName", SqlDbType.VarChar).Value = cName;
            cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = pName;
            cmd.Parameters.Add("@price", SqlDbType.Float).Value = price;
            cmd.Parameters.Add("@tot", SqlDbType.Float).Value = tot;
            cmd.Parameters.Add("@dis", SqlDbType.Float).Value = dis;
            cmd.Parameters.Add("@gTot", SqlDbType.Float).Value = gTot;
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

        public DataTable getBill(SqlCommand cmd)
        {
            cmd.Connection = con.GetConnection;
            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adpter.Fill(table);
            return table;
        }

    }
}
