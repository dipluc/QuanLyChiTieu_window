using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DuLieu
{
    public static class KetNoiCSDL
    {
        // Chuỗi kết nối lấy tự động theo vị trí thực tế của file QLChiTieu.mdf
        public static string LayChuoiKetNoi()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // 1. Kiểm tra nếu có DataDirectory
            string dataDir = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (!string.IsNullOrEmpty(dataDir))
            {
                string pData1 = Path.Combine(dataDir, "Database", "QLChiTieu.mdf");
                if (File.Exists(pData1)) return TaoChuoiKetNoi(pData1);
                string pData2 = Path.Combine(dataDir, "QLChiTieu.mdf");
                if (File.Exists(pData2)) return TaoChuoiKetNoi(pData2);
            }

            // 2. Tìm ngược lên các thư mục cha (khi debug/chạy trong Visual Studio hoặc kiểm thử)
            string[] searchRoots = new string[] { baseDir, Directory.GetCurrentDirectory() };
            foreach (var root in searchRoots)
            {
                if (string.IsNullOrEmpty(root)) continue;
                try
                {
                    DirectoryInfo cur = new DirectoryInfo(root);
                    while (cur != null)
                    {
                        string pProject = Path.Combine(cur.FullName, "LTWIN_N05_QLCT", "Database", "QLChiTieu.mdf");
                        if (File.Exists(pProject)) return TaoChuoiKetNoi(pProject);

                        string pDb = Path.Combine(cur.FullName, "Database", "QLChiTieu.mdf");
                        if (File.Exists(pDb)) return TaoChuoiKetNoi(pDb);

                        cur = cur.Parent;
                    }
                }
                catch { }
            }

            // 3. Kiểm tra các vị trí mặc định thông dụng
            string[] possiblePaths = new string[]
            {
                Path.GetFullPath(Path.Combine(baseDir, @"..\..\Database\QLChiTieu.mdf")),
                Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\LTWIN_N05_QLCT\Database\QLChiTieu.mdf")),
                Path.Combine(baseDir, "Database", "QLChiTieu.mdf"),
                Path.Combine(baseDir, "QLChiTieu.mdf")
            };

            foreach (var p in possiblePaths)
            {
                if (File.Exists(p))
                {
                    return TaoChuoiKetNoi(p);
                }
            }

            try
            {
                var connSetting = ConfigurationManager.ConnectionStrings["Conn_QLChiTieu"];
                if (connSetting != null && !string.IsNullOrEmpty(connSetting.ConnectionString))
                {
                    return connSetting.ConnectionString;
                }
            }
            catch { }

            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\QLChiTieu.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private static string TaoChuoiKetNoi(string duongDanMdf)
        {
            return string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30", duongDanMdf);
        }

        // Mở kết nối
        public static SqlConnection LayKetNoi()
        {
            var conn = new SqlConnection(LayChuoiKetNoi());
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        // Kiểm tra kết nối nhanh
        public static bool KiemTraKetNoi()
        {
            try
            {
                using (var conn = LayKetNoi())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Lỗi kết nối cơ sở dữ liệu: " + ex.Message,
                    "Lỗi hệ thống",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        // Đọc dữ liệu (SELECT) trả về DataTable
        public static DataTable DocDuLieu(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = LayKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // Thực thi câu lệnh INSERT, UPDATE, DELETE
        public static int ThucThiLenh(string sql, params SqlParameter[] parameters)
        {
            using (var conn = LayKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        // Lấy một giá trị duy nhất (ExecuteScalar)
        public static object LayMotGiaTri(string sql, params SqlParameter[] parameters)
        {
            using (var conn = LayKetNoi())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
