using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Management_System_Simple.AllUserControls;

namespace Restaurant_Management_System_Simple
{
    class DatabaseConnection
    {
        private string connectionString = "Data Source=DESKTOP-TP6N7M4\\SQLEXPRESS;Initial Catalog=restro;Integrated Security=True;Encrypt=True";

        // Method to open the connection
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Could not open connection to the database: " + ex.Message);
            }
            return connection;
        }

        // Method to close the connection
        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not close the connection to the database: " + ex.Message);
            }
        }
        public DataSet GetData(String qry)
        {
            try
            {
                SqlConnection con = OpenConnection();
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Connection = con;
                cmd.CommandText = qry;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (SqlException)
            {
                return null;
            }

        }
    }
}

