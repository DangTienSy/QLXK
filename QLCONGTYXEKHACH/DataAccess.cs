using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCONGTYXEKHACH
{
    public class DataAccess
    {
        public string connectionString = "Data Source=MSI;Initial Catalog=QLCONGTYXEKHACH;Integrated Security=True";
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dt);
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
            return dt;
        }
        public string GetFirstCellValue(string query)
        {
            string s = "";
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dt);
                    if(dt.Rows.Count > 0) s= dt.Rows[0][0].ToString();
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
            return s;
        }
        public bool Connect(string cnnString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cnnString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show("Kết nối thất bại " + m.Message);
                return false;
            }
        }
        public void Disconnect()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Close();
                }
            }
            catch (Exception m)
            {
                MessageBox.Show("Thất bại " + m.Message);
            }
        }
        public bool Connect()
        {
            return Connect(connectionString);
        }
        public bool Execute(string query)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    success = sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }

            return success;
        }
    }

}
