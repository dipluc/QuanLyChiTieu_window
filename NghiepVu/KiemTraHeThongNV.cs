using System;
using System.Data;
using DuLieu;

namespace NghiepVu
{
    public static class KiemTraHeThongNV
    {
        // Chỉ đọc dữ liệu để kiểm tra đúng đường kết nối của ứng dụng.
        public static string KiemTraCoSoDuLieu()
        {
            using (DataTable result = KetNoiCSDL.DocDuLieu(
                "SELECT DB_NAME() AS TenCSDL, " +
                "(SELECT COUNT(*) FROM sys.tables) AS SoBang, " +
                "(SELECT COUNT(*) FROM dbo.NguoiDung) AS SoNguoiDung, " +
                "(SELECT physical_name FROM sys.database_files WHERE file_id = 1) AS TepDuLieu"))
            {
                DataRow row = result.Rows[0];
                return string.Format("Database={0}; Tables={1}; Users={2}; File={3}",
                    row["TenCSDL"], row["SoBang"], row["SoNguoiDung"], row["TepDuLieu"]);
            }
        }
    }
}
