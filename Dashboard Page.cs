using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Project
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Display1();
            Display2();
            Display3();
        }

       
 private void Display1()
        {
            string connectionString = "Data Source=LAPTOP-N9GC6JS6\\SQLEXPRESS;Initial Catalog=marketdb;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to count rows in the table
                    string query = "SELECT COUNT(*) FROM products";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in the label
                        lblCount1.Text = "Total Products: " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    



   
 private void Display2()
        {
            string connectionString = "Data Source=LAPTOP-N9GC6JS6\\SQLEXPRESS;Initial Catalog=marketdb;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to count rows in the table
                    string query = "SELECT COUNT(*) FROM customers";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in the label
                        lblCount2.Text = "Total Customers: " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

       



 private void Display3()
        {
            string connectionString = "Data Source=LAPTOP-N9GC6JS6\\SQLEXPRESS;Initial Catalog=marketdb;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // SQL query to count rows in the table
                    string query = "SELECT COUNT(*) FROM orders";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in the label
                        lblCount3.Text = "Total Orders: " + count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
