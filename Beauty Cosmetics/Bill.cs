using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Beauty_Cosmetics
{
    public partial class Bill : Form
    {
        ClassBill bill = new ClassBill();
        public Bill()
        {
            InitializeComponent();
        }
        public void showData()
        {
            //to show Bill list on datagridview
            dataGrid0ViewBill.DataSource = bill.getBill(new SqlCommand("SELECT * FROM tbl_employees"));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //To Search Bill and show on datagridview
            dataGrid0ViewBill.DataSource = bill.getBill(new SqlCommand("SELECT * FROM tbl_bill WHERE CONCAT(bill_id)LIKE '%" + txtSearch.Text + "%'"));
            txtSearch.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBillId.Clear();
            txtCustomerName.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtTotal.Clear();
            txtDiscount.Clear();
            txtGrandTotal.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBillId.Text == "" || txtCustomerName.Text == "" || txtProductName.Text == "" || txtPrice.Text == "" || txtQty.Text=="" || txtQty.Text=="" || txtTotal.Text=="" || txtDiscount.Text=="" || txtGrandTotal.Text=="")
            {
                MessageBox.Show("Need Bill detais", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string bId = txtBillId.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string cName = txtCustomerName.Text;
                string pName = txtProductName.Text;
                float price = Convert.ToInt32(txtPrice.Text);
                float qty = Convert.ToInt32(txtQty.Text);
                float tot = Convert.ToInt32(txtTotal.Text);
                float dis = Convert.ToInt32(txtDiscount.Text);
                float gTot = Convert.ToInt32(txtGrandTotal.Text);

                if (bill.insetBill(bId, date, cName, pName, price, qty, tot, dis, gTot))
                {
                    showData();
                    btnClear.PerformClick();
                    MessageBox.Show("New Employee inserted", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Employee not insert", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void dataGrid0ViewBill_Click(object sender, EventArgs e)
        {
            txtBillId.Text = dataGrid0ViewBill.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGrid0ViewBill.CurrentRow.Cells[1].Value;
            txtCustomerName.Text = dataGrid0ViewBill.CurrentRow.Cells[2].Value.ToString();
            txtProductName.Text = dataGrid0ViewBill.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Text = dataGrid0ViewBill.CurrentRow.Cells[4].Value.ToString();
            txtQty.Text = dataGrid0ViewBill.CurrentRow.Cells[5].Value.ToString();
            txtTotal.Text = dataGrid0ViewBill.CurrentRow.Cells[6].Value.ToString();
            txtDiscount.Text = dataGrid0ViewBill.CurrentRow.Cells[7].Value.ToString();
            txtGrandTotal.Text = dataGrid0ViewBill.CurrentRow.Cells[8].Value.ToString();
            
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            float tot = Convert.ToInt32(txtTotal.Text);
            float dis = Convert.ToInt32(txtDiscount);

            txtGrandTotal.Text = Convert.ToString(tot + (tot * dis));
        }

       

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            float price = Convert.ToInt32(txtPrice.Text);
            float qty = Convert.ToInt32(txtQty.Text);

            txtTotal.Text = Convert.ToString((price * qty));
        }
    }
}
