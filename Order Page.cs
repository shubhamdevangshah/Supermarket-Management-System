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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int orderid  = int.Parse(textBox1.Text);
            int customerid = int.Parse(textBox2.Text);
            int productid = int.Parse(textBox3.Text); 
            decimal amount = decimal.Parse(textBox4.Text);
            decimal quantity = decimal.Parse(textBox5.Text);

            string query = "INSERT INTO orders (OrderID, CustomerID, ProductID, Quantity, Amount) VALUES (@OrderID, @CustomerID, @ProductID, @Quantity, @Amount)";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderid);
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Inserted Successfully");
            OrderData();
        }

        private void OrderData()
        {
            string query = "SELECT * FROM orders";
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
            int orderid = int.Parse(textBox1.Text);
            int customerid = int.Parse(textBox2.Text);
            int productid = int.Parse(textBox3.Text);
            decimal quantity = decimal.Parse(textBox4.Text);
            decimal amount = decimal.Parse(textBox5.Text);

            string query = "UPDATE orders SET CustomerID=@CustomerID, ProductID=@productID, Quantity=@Quantity, Amount=@Amount WHERE OrderID=@OrderID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderid);
                    cmd.Parameters.AddWithValue("@CustomerID", customerid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Updated Successfully");
            OrderData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int orderid = int.Parse(textBox1.Text);
          
            string query = "Delete FROM orders WHERE OrderID=@OrderID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderid);
                   
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Deleted Successfully");
            OrderData();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            OrderData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
