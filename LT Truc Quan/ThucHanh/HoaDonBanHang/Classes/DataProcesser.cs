using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoaDonBanHang.Classes
{
    internal class DataProcesser
    {
        string strConnect = "Server=DESKTOP-FTUKUSM;DataBase=QLBanHang;Integrated Security=true";
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

       
        


        public bool CheckLogin(string MaNhanVien, string MatKhau)
        {
            bool isValid = false;
            string sql = "SELECT COUNT(*) FROM tblNhanVien WHERE MaNhanVien = @MaNhanVien AND MatKhau = @MatKhau";

            OpenConnection();

            using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConncect))
            {
                // Sử dụng tham số để tránh SQL Injection
                sqlCommand.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                sqlCommand.Parameters.AddWithValue("@MatKhau", MatKhau);

                int count = (int)sqlCommand.ExecuteScalar();
                if (count > 0)
                {
                    isValid = true;
                }
            }

            CloseConnection();
            return isValid;
        }

        public List<string> GetAllEmployeeIds()
        {
            List<string> employeeIds = new List<string>();
            string sql = "SELECT MaNhanVien FROM tblNhanVien"; // SQL query to get all employee IDs

            try
            {
                OpenConnection(); // Mở kết nối cơ sở dữ liệu

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConncect))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employeeIds.Add(reader["MaNhanVien"].ToString()); // Thêm mỗi mã nhân viên vào danh sách
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách mã nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection(); // Đóng kết nối
            }

            return employeeIds;
        }
        public string GetEmployeeNameById(string maNhanVien)
        {
            string tenNhanVien = "";
            string sql = "SELECT TenNhanVien FROM tblNhanVien WHERE MaNhanVien = @MaNV";

            try
            {
                OpenConnection();

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConncect))
                {
                    sqlCommand.Parameters.AddWithValue("@MaNV", maNhanVien);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenNhanVien = reader["TenNhanVien"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tên nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return tenNhanVien;
        }



    }
}
