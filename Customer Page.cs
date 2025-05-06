using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int customerid = int.Parse(textBox1.Text);
            string customername = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;

            string query = "INSERT INTO customers (CustomerID, CustomerName, Phone, Address) VALUES (@CustomerID, @CustomerName, @Phone, @Address)";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@CustomerName", customername);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Inserted Successfully");
            CustomerData();
        }

        private void CustomerData()
        {
            string query = "SELECT * FROM customers";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerid = int.Parse(textBox1.Text);
            string customername = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;

            string query = "UPDATE customers SET CustomerName=@CustomerName, Phone=@Phone, Address=@Address WHERE CustomerID=@CustomerID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@CustomerName", customername);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Updated Successfully");
            CustomerData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int customerid = int.Parse(textBox1.Text);

            string query = "DELETE FROM customers WHERE CustomerID=@CustomerID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Deleted Successfully");
            CustomerData();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            CustomerData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}