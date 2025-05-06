using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace Project
{
    internal class DatabaseConnection
    {
        private SqlConnection connection;

        public DatabaseConnection()
        {
            string connectString = "Data Source=LAPTOP-N9GC6JS6\\SQLEXPRESS;Initial Catalog=marketdb;Integrated Security=True;Encrypt=False";
            connection = new SqlConnection(connectString);
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
