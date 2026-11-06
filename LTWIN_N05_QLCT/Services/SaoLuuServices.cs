using DuLieu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTWIN_N05_QLCT.Services
{
    internal class SaoLuuServices
    {
        public static string LayThuMuc(string thuMucDaLuu)
        {
            if (string.IsNullOrWhiteSpace(thuMucDaLuu))
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuanLyChiTieu", "SaoLuu");
            }
            return Path.GetFullPath(thuMucDaLuu.Trim());
        }

        public static string TaoBanSaoLuu(string thuMuc)
        {
            thuMuc = LayThuMuc(thuMuc);
            Directory.CreateDirectory(thuMuc);

            string tenTep = "ChiTieu_" +
                DateTime.Now.ToString("yyyy-MM-dd_HHmmss_fff") +
                "_" + Guid.NewGuid().ToString("N").Substring(0, 8) +
                ".bak";

            string duongDan = Path.Combine(thuMuc, tenTep);

            using (SqlConnection conn = KetNoiCSDL.LayKetNoi())
            {
                string tenDatabase = conn.Database;

                if (string.IsNullOrWhiteSpace(tenDatabase) ||
                    tenDatabase.Equals(
                        "master",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "Không xác định được database cần sao lưu.");
                }

                string tenSql =
                    "[" + tenDatabase.Replace("]", "]]") + "]";

                string sql = "BACKUP DATABASE " + tenSql +
                    " TO DISK = @tep WITH COPY_ONLY, CHECKSUM;";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300;

                    cmd.Parameters.Add(
                        "@tep", SqlDbType.NVarChar, 4000
                    ).Value = duongDan;

                    cmd.ExecuteNonQuery();
                }
            }

            return duongDan;
        }
    }
}
