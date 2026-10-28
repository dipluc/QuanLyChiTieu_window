using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DuLieu
{
    public class KetNoiCSDL
    {
        // Lấy chuỗi kết nối từ App.config của tầng GUI
        private static string strCon = ConfigurationManager.ConnectionStrings["Conn_QLChiTieu"].ConnectionString;

        // Hàm mở kết nối
        public static SqlConnection LayKetNoi()
        {
            SqlConnection conn = new SqlConnection(strCon);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        // Hàm kiểm tra kết nối nhanh trước khi mở app
        public static bool KiemTraKetNoi()
        {
            try
            {
                using (SqlConnection conn = LayKetNoi())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, 
                                                    "Lỗi hệ thống", 
                                                    System.Windows.Forms.MessageBoxButtons.OK, 
                                                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}