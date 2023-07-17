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
    public partial class Employees : Form
    {
        ClassEmployees employees = new ClassEmployees();
        public Employees()
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
            dataGridViewEmployees.DataSource = employees.getEmployees(new SqlCommand("SELECT * FROM tbl_employees"));
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //To Search customer and show on datagridview
            dataGridViewEmployees.DataSource = employees.getEmployees(new SqlCommand("SELECT * FROM tbl_employees WHERE CONCAT(employee_name)LIKE '%" + txtSearch.Text + "%'"));
            txtSearch.Clear();
        }

        private void dataGridViewEmployees_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Text = dataGridViewEmployees.CurrentRow.Cells[0].Value.ToString();
            txtEmployeeName.Text = dataGridViewEmployees.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dataGridViewEmployees.CurrentRow.Cells[2].Value.ToString();
            txtContactNo.Text = dataGridViewEmployees.CurrentRow.Cells[3].Value.ToString();
            comboBoxGender.SelectedItem = dataGridViewEmployees.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridViewEmployees.CurrentRow.Cells[5].Value;
            txtAddress.Text = dataGridViewEmployees.CurrentRow.Cells[6].Value.ToString();
            txtSalary.Text = dataGridViewEmployees.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "" || txtEmployeeName.Text == "" || txtEmail.Text == "" || txtContactNo.Text == "")
            {
                MessageBox.Show("Need Employee data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string eId = txtEmployeeId.Text;
                string eName = txtEmployeeName.Text;
                string email = txtEmail.Text;
                string contact = txtContactNo.Text;
                string gender = comboBoxGender.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string address = txtAddress.Text;
                string sal =txtSalary.Text;

                if (employees.insertEmployee(eId, eName, email, contact,gender,date, address,sal))
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == "" || txtEmployeeName.Text == "" || txtEmail.Text == "" || txtContactNo.Text == "")
            {
                MessageBox.Show("Need Employee data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string eId = txtEmployeeId.Text;
                string eName = txtEmployeeName.Text;
                string email = txtEmail.Text;
                string contact = txtContactNo.Text;
                string gender = comboBoxGender.Text;
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string address = txtAddress.Text;
                string sal = txtSalary.Text;

                if (employees.updateEmployees(eId, eName, email, contact, gender, date, address, sal))
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //remove the selected Employee
            string eId = txtEmployeeId.Text;
            //Show a confirmation message before delete the employee
            if (MessageBox.Show("Are you sure you want to remove this employee", "Remove Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (employees.deleteEmployee(eId))
                {
                    showData();
                    MessageBox.Show("Employee Removed", "Remove Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear.PerformClick();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Clear();
            txtEmployeeName.Clear();
            txtEmail.Clear();
            txtContactNo.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
        }

    }
}
