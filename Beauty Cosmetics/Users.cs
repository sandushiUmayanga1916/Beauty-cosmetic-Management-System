using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Beauty_Cosmetics
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void Users_Load(object sender, EventArgs e)
        {
            showData();
            
        }

       

        private void showData()
        {
            con.Open();
            string list = "select * from tbl_users";
            OleDbDataAdapter da = new OleDbDataAdapter(list, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_users");
            dataGridViewUsers.DataSource = ds.Tables[0];
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewUsers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Sure you wanna delete?", "Warning", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridViewUsers.SelectedRows)
                    {
                        dataGridViewUsers.Rows.RemoveAt(item.Index);
                    }
                
                    btnClear.PerformClick();
                    dataGridViewUsers.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a row", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUsers_Click(object sender, EventArgs e)
        {
            txtUsername.Text = dataGridViewUsers.CurrentRow.Cells[0].Value.ToString();
            txtPassword.Text = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
