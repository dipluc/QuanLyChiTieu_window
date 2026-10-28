using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DuLieu
{
    public static class KetNoiCSDL
    {
        // Chuỗi kết nối đến file QLChiTieu.mdf nằm trong project GUI
        public static string ChuoiKetNoi = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QLChiTieu.mdf;Integrated Security=True";

        // Hàm đọc dữ liệu (SELECT) trả về DataTable
        public static bool KiemTraKetNoi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
                {
                    conn.Open();
                    MessageBox.Show("Kết nối cơ sở dữ liệu thành công!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thất bại!\nChi tiết: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        // Hàm đọc dữ liệu (SELECT) trả về DataTable
        public static DataTable DocDuLieu(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        conn.Open(); // mở kết nối để xác nhận thành công
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu: " + ex.Message,
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            return dt;
        }

        // Hàm thực thi câu lệnh (INSERT, UPDATE, DELETE)
        public static int ThucThiLenh(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Hàm lấy một giá trị duy nhất (ExecuteScalar)
        public static object LayMotGiaTri(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ChuoiKetNoi))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}