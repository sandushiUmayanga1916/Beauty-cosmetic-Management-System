using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Beauty_Cosmetics
{
    class ClassStock
    {
        DBConnect con = new DBConnect();
        //create a function to insert Stock

        public bool insertStock(string pId, string pName, string brand, int qty, float price,float tot, string date)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_stock('product_id','product_name','brand','quantity','price','total_price','date' ) VALUES ('@pId','@pName','@brand','@qty','@price','@tot','@date') ", con.GetConnection);
            //@pId,@pName,@brand,@qty,@price,@tot,@date
            cmd.Parameters.Add("@pId", SqlDbType.VarChar).Value = pId;
            cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = pName;
            cmd.Parameters.Add("@brand", SqlDbType.VarChar).Value = brand;
            cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty;
            cmd.Parameters.Add("@price", SqlDbType.Float).Value =price;
            cmd.Parameters.Add("@tot", SqlDbType.Float).Value = tot;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
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

        //create a function to get Stock list

        public DataTable getStock(SqlCommand cmd)
        {
            cmd.Connection = con.GetConnection;
            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adpter.Fill(table);
            return table;
        }

        //create a update function for stock edit

        public bool updateStock(string pId, string pName, string brand, int qty, float price, float tot, string date)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_stock SET 'product_id'=@pId,'product_name' = @pName,'brand'=@brand,'quantity'=@qty,'price'=@price WHERE product_id=@pId", con.GetConnection);
            //@pId,@pName,@brand,@qty,@price,@tot,@date
            cmd.Parameters.Add("@pId", SqlDbType.VarChar).Value = pId;
            cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = pName;
            cmd.Parameters.Add("@brand", SqlDbType.VarChar).Value = brand;
            cmd.Parameters.Add("@qty", SqlDbType.Int).Value = qty;
            cmd.Parameters.Add("@price", SqlDbType.Float).Value = price;
            cmd.Parameters.Add("@tot", SqlDbType.Float).Value = tot;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
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

        //create a function to delete a stock
        //we only need product id

        public bool deleteStock(string pId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl_stock WHERE 'product_id'=@pId", con.GetConnection);
            cmd.Parameters.Add("@pId", SqlDbType.VarChar).Value = pId;
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
