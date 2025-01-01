using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de2.Classes
{
    internal class DataProcesser
    {
        string strConnect = "Data Source=DESKTOP-FTUKUSM;" + "DataBase=DuLieu;Integrated Security=true";
        SqlConnection sqlConncect = null;

        //Open a connection to Server
        void OpenConnection()
        {
            sqlConncect = new SqlConnection(strConnect);
            if (sqlConncect.State != ConnectionState.Open)
                sqlConncect.Open();
        }

        //Close a Connection
        void CloseConnection()
        {
            if (sqlConncect.State != ConnectionState.Closed)
            {
                sqlConncect.Close();
                sqlConncect.Dispose();
            }
        }
        //read Data from a Select statement and return a DataTable
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlSelect, sqlConncect);
            dataAdapter.Fill(dt);
            CloseConnection();
            dataAdapter.Dispose();
            return dt;
        }

        //Change Data 
        public void ChangeData(string sql)
        {
            OpenConnection();
            SqlCommand sqlcmm = new SqlCommand();
            sqlcmm.Connection = sqlConncect;
            sqlcmm.CommandText = sql;
            sqlcmm.ExecuteNonQuery();
            CloseConnection();
            sqlcmm.Dispose();
        }
        public int ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            int result = 0;
            OpenConnection();
            using (SqlCommand command = new SqlCommand(sql, sqlConncect))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }
                result = Convert.ToInt32(command.ExecuteScalar());
            }
            CloseConnection();
            return result;
        }

    }
}
