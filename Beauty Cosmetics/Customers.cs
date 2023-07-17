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
    public partial class Customers : Form
    {
        ClassCustomers customers = new ClassCustomers();
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            showData();
        }

        //show data of the customers
        private void showData()
        {
            //to show customers list on datagridview
            dataGridViewCustomers.DataSource = customers.getCustomers(new SqlCommand("SELECT * FROM tbl_customers"));
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtCustomerId.Text=="" || txtCusName.Text=="" || txtEmail.Text=="" || txtContactNo.Text=="" || txtAddress.Text=="")
            {
                MessageBox.Show("Need Customer data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string cId = txtCustomerId.Text;
                string cName = txtCusName.Text;
                string email = txtEmail.Text;
                string contact = txtContactNo.Text;
                string address = txtAddress.Text;
                if(customers.updateCustomer(cId,cName,email,contact,address))
                {
                    showData();
                    btnAdd.PerformClick();
                    MessageBox.Show("Customer Update Successfuly", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error-Customer not Edit", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtCustomerId.Text.Equals(""))
            {
                MessageBox.Show("Need Customer Id", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string cId = txtCustomerId.Text;
                    if(customers.deleteCustomer(cId))
                    {
                        showData();
                        btnAdd.PerformClick();
                        MessageBox.Show("customer Deleted", "Removed Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Removed Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //To Search customer and show on datagridview
            dataGridViewCustomers.DataSource = customers.getCustomers(new SqlCommand("SELECT * FROM tbl_customers WHERE CONCAT(customer_name)LIKE '%" + txtSearch.Text + "%'"));
            txtSearch.Clear();
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewCustomers_Click(object sender, EventArgs e)
        {
            txtCustomerId.Text = dataGridViewCustomers.CurrentRow.Cells[0].Value.ToString();
            txtCusName.Text = dataGridViewCustomers.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dataGridViewCustomers.CurrentRow.Cells[2].Value.ToString();
            txtContactNo.Text = dataGridViewCustomers.CurrentRow.Cells[3].Value.ToString();
            txtAddress.Text = dataGridViewCustomers.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCustomerId.Text == "" || txtCusName.Text == "" || txtEmail.Text == "" || txtContactNo.Text==""||txtAddress.Text=="")
            {
                MessageBox.Show("Need Customer data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string cId = txtCustomerId.Text;
                string cName = txtCusName.Text;
                string email = txtEmail.Text;
                string contact = txtContactNo.Text;
                string address = txtAddress.Text;

                if(customers.insetCustomers(cId,cName,email,contact,address))
                {
                    showData();
                    btClear.PerformClick();
                    MessageBox.Show("New Customers inserted", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not insert", "Add customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            txtCustomerId.Clear();
            txtCusName.Clear();
            txtEmail.Clear();
            txtContactNo.Clear();
            txtAddress.Clear();
        }
    }
}
