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
    public partial class Stock : Form
    {
        ClassStock stock = new ClassStock();
        public Stock()
        {
            InitializeComponent();
        }

        public void showData()
        {
            //to show Stock list on datagridview
            dataGridViewStock.DataSource = stock.getStock(new SqlCommand("SELECT * FROM tbl_stock"));
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "" || txtProductName.Text == "" || comboBoxBrand.Text == "" || txtQuantity.Text == ""|| txtPrice.Text=="" || txtTotal.Text=="")
            {
                MessageBox.Show("Need Product data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string pId = txtProductId.Text;
                string pName = txtProductName.Text;
                string brand = comboBoxBrand.Text;
                int qty = Convert.ToInt32(txtQuantity.Text);
                float price = Convert.ToInt32(txtPrice.Text);
                float tot = Convert.ToInt32(txtTotal.Text);
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                if (stock.insertStock(pId, pName, brand, qty, price, tot, date))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // To Search Stock and show on datagridview
            dataGridViewStock.DataSource = stock.getStock(new SqlCommand("SELECT * FROM tbl_stock WHERE CONCAT(product_name)LIKE '%" + txtSearch.Text + "%'"));
            txtSearch.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtTotal.Clear();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //remove the selected Product
            string pId = txtProductId.Text;
            //Show a confirmation message before delete the product
            if (MessageBox.Show("Are you sure you want to remove this product", "Remove Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (stock.deleteStock(pId))
                {
                    showData();
                    MessageBox.Show("Product Removed", "Remove Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "" || txtProductName.Text == "" || comboBoxBrand.Text == "" || txtQuantity.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Need Product data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string pId = txtProductId.Text;
                string pName = txtProductName.Text;
                string brand = comboBoxBrand.Text;
                int qty = Convert.ToInt32(txtQuantity.Text);
                float price = Convert.ToInt32(txtPrice.Text);
                float tot = Convert.ToInt32(txtTotal.Text);
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                if (stock.updateStock(pId, pName, brand, qty, price, tot, date))
                {
                    showData();
                    btnClear.PerformClick();
                    MessageBox.Show("New Product inserted", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Product not insert", "Add product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewStock_Click(object sender, EventArgs e)
        {
            txtProductId.Text = dataGridViewStock.CurrentRow.Cells[0].Value.ToString();
            txtProductName.Text = dataGridViewStock.CurrentRow.Cells[1].Value.ToString();
            comboBoxBrand.SelectedItem = dataGridViewStock.CurrentRow.Cells[2].Value.ToString();
            txtQuantity.Text = dataGridViewStock.CurrentRow.Cells[3].Value.ToString();
            txtPrice.Text = dataGridViewStock.CurrentRow.Cells[4].Value.ToString();
            txtTotal.Text = dataGridViewStock.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridViewStock.CurrentRow.Cells[6].Value;
            
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            showData();
        }
    }
}
