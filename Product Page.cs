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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int productid = int.Parse(textBox1.Text);
            string productname = textBox2.Text;
            string category = textBox3.Text;
            decimal price = decimal.Parse(textBox4.Text);

            string query = "INSERT INTO products (ProductID, ProductName, Category, Price) VALUES (@ProductID, @ProductName, @Category, @Price)";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@ProductName", productname);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Inserted Successfully");
            ProductData();
        }

        private void ProductData()
        {
            string query = "SELECT * FROM products";
            using (SqlConnection conn  = new DatabaseConnection().GetConnection())
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
            int productid = int.Parse(textBox1.Text);
            string productname = textBox2.Text;
            string category = textBox3.Text;
            decimal price = decimal.Parse(textBox4.Text);

            string query = "UPDATE products SET ProductName=@ProductName, Category=@Category, Price=@Price WHERE ProductID=@ProductID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@ProductName", productname);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Updated Successfully");
            ProductData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productid = int.Parse(textBox1.Text);
            
            string query = "DELETE FROM products WHERE ProductID=@ProductID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                   
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Deleted Successfully");
            ProductData();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            ProductData();
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
