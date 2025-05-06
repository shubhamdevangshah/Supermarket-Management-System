using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Inventory : Form
    {
        private object iid;

        public Inventory()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int iid = int.Parse(textBox1.Text);
            int productid = int.Parse(textBox2.Text);
            decimal stockadded = decimal.Parse(textBox3.Text);
            decimal stockremoved = decimal.Parse(textBox4.Text);

            string query = "INSERT INTO inventory (IID, ProductID, StockAdded, StockRemoved) VALUES (@IID, @ProductID, @StockAdded, @StockRemoved)";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IID", iid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@StockAdded", stockadded);
                    cmd.Parameters.AddWithValue("@StockRemoved", stockremoved);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Inserted Successfully");
            InventoryData();
        }

        private void InventoryData()
        {
            string query = "SELECT * FROM inventory";
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
            int iid = int.Parse(textBox1.Text);
            int productid = int.Parse(textBox2.Text);
            decimal stockadded = decimal.Parse(textBox3.Text);
            decimal stockremoved = decimal.Parse(textBox4.Text);

            string query = "UPDATE inventory SET ProductID=@ProductID, StockAdded=@StockAdded, StockRemoved=@StockRemoved WHERE IID=@IID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IID", iid);
                    cmd.Parameters.AddWithValue("@ProductID", productid);
                    cmd.Parameters.AddWithValue("@StockAdded", stockadded);
                    cmd.Parameters.AddWithValue("@StockRemoved", stockremoved);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Updated Successfully");
            InventoryData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int orderid = int.Parse(textBox1.Text);

          
  string query = "DELETE FROM inventory WHERE IID=@IID";
            using (SqlConnection conn = new DatabaseConnection().GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IID", iid);

                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Recorded Deleted Successfully");
            InventoryData();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            InventoryData();
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
